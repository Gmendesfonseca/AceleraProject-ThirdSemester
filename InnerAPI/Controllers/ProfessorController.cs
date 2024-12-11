using InnerAPI.Services;
using InnerAPI.Models;
using InnerAPI.Dtos.Professor;

namespace InnerAPI.Controllers
{
    public static class ProfessorController
    {
        public static RouteGroupBuilder MapProfessorEndpoint(this WebApplication app, SharedService sharedService)
        {
            ProfessorServices professorServices = new ProfessorServices(sharedService);
            var group = app.MapGroup("professor").WithParameterValidation();


            // GET /professor/{id}
            group.MapGet("{id}", (uint id) =>
            {
                var professor = professorServices.GetProfessors(id);
                if (professor == null)
                {
                    return Results.NotFound($"Professor com ID {id} não encontrado.");
                }
                return Results.Ok(professor);
            });

            // POST /professor/register
            group.MapPost("/register", (RegisterProfessorDto professor) =>
            {
                professorServices.Register(professor);
                return Results.Ok(professor);
            });

            // PUT /professor/id
            group.MapPut("/{id}", (uint id, Professor professor) =>
            {
                var professorToUpdate = professorServices.GetProfessors(id);
                professorToUpdate = professor;
                return Results.Ok(professorToUpdate);
            });

            //DELETE /professor/{id}
            group.MapDelete("/{id}", (uint id) =>
            {
                bool deleted = professorServices.Delete(id);
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
