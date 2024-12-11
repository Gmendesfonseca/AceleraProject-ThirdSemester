using InnerAPI.Dtos;
using InnerAPI.Dtos.HeadOffice;
using InnerAPI.Models;
using InnerAPI.Services;
using InnerAPI.Utils;

namespace InnerAPI.Controllers
{
  public static class HeadOfficeController
  {
    const string GetNameHeadOfficeEndpoint = "GetheadOffice";
    public static RouteGroupBuilder MapHeadOfficeEndpoint(this WebApplication app, SharedService sharedService)
    {
      var group = app.MapGroup("headoffice").WithParameterValidation();
      List<HeadOffice> headOffices = sharedService.HeadOffices;
      HeadOfficeServices headOfficeServices = new HeadOfficeServices(sharedService);

        //GET /headoffice/{id}/branches
        group.MapGet("/{id}/branches", (uint id) =>
        {
            HeadOffice? headOffice = headOffices.Find(headOffice => headOffice.Id == id);
            if (headOffice == null)
            {
                return Results.BadRequest(new { success = false, message = "headOffice not found" });
            }
            return Results.Ok(headOffice.Branches);
        });

        //GET /headoffice/{id}
        group.MapGet("/{id}", (uint id) =>
        {
            HeadOffice? headOffice = headOffices.Find(headOffice => headOffice.Id == id);
            return headOffice is null ? Results.NotFound() : Results.Ok(headOffice);
        }).WithName(GetNameHeadOfficeEndpoint);



      // POST /headoffice/register
      group.MapPost("/register", (RegisterHeadOfficeDto newheadOffice) =>
      {
        var exists = headOffices.Exists(r => r.Name == newheadOffice.Name || r.Email == newheadOffice.Email || r.CNPJ == newheadOffice.CNPJ || r.Domain == newheadOffice.Domain);
        if (!exists)
        {
          var createdHeadOffice = headOfficeServices.Register(newheadOffice);
          return Results.CreatedAtRoute(GetNameHeadOfficeEndpoint, new { id = createdHeadOffice.Id }, createdHeadOffice);
        }
        else
        {
          return Results.BadRequest(new { success = false, message = "Name, Email, CNPJ, or Domain already used" });
        }
      });

      // PUT /headoffice/{id}
      group.MapPut("/{id}", (uint id, UpdateHeadOfficeDto updateHeadOffice) =>
      {
        var index = headOffices.FindIndex(headOffice => headOffice.Id == id);

        if (index == -1)
        {
          return Results.NotFound();
        }

        headOffices[index] = new HeadOffice(
                  id,
                  updateHeadOffice.Name,
                  updateHeadOffice.Email,
                  updateHeadOffice.Password,
                  updateHeadOffice.Domain,
                  updateHeadOffice.CNPJ);

        return Results.NoContent();
      });

      // DELETE /headoffice/{id}
      group.MapDelete("/{id}", (int id) =>
      {
        bool deleted = headOfficeServices.Delete(id); // Corrigido para usar um método que retorna um booleano
        if (!deleted)
        {
          return Results.NotFound();
        }
        return Results.NoContent();
      });

      return group;
    }
  }
}
