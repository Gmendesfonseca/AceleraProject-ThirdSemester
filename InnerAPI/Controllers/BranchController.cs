using InnerAPI.Dtos.Branch;
using InnerAPI.Models;
using InnerAPI.Services;
using InnerAPI.Utils;

namespace InnerAPI.Controllers
{
    public static class BranchController
    {
        const string GetNameBranchEndpoint = "GetBranch";
        public static RouteGroupBuilder MapBranchEndpoint(this WebApplication app, SharedService sharedService)
        {
            var group = app.MapGroup("branch").WithParameterValidation();
            List<Branch> branches = sharedService.Branches;
            BranchServices branchServices = new BranchServices(sharedService);

            //GET /branch/{id}
            group.MapGet("/{id}", (uint id) =>
            {
                Branch? branch = branches.Find(Branch => Branch.Id == id);
                return branch is null ? Results.NotFound() : Results.Ok(branch);
            }).WithName(GetNameBranchEndpoint);

            //GET /branch/{id}/students
            group.MapGet("/{id}/students", (uint id) =>
            {
                Branch? branch = branches.Find(Branch => Branch.Id == id);
                if (branch == null)
                {
                    return Results.BadRequest(new { success = false, message = "Branch not found" });
                }
                return Results.Ok(branch.Students);
            });

            //GET /branch/{id}/professors
            group.MapGet("/{id}/professors", (uint id) =>
            {
                Branch? Branch = branches.Find(Branch => Branch.Id == id);
                if (Branch == null)
                {
                    return Results.BadRequest(new { success = false, message = "Branch not found" });
                }
                return Results.Ok(Branch.Professors);
            });

            //GET /branch/{id}/courses
            group.MapGet("/{id}/courses", (uint id) =>
            {
                Branch? Branch = branches.Find(Branch => Branch.Id == id);
                if (Branch == null)
                {
                    return Results.BadRequest(new { success = false, message = "Branch not found" });
                }
                return Results.Ok(Branch.Courses);
            });

            // POST /branch/register
            group.MapPost("/register", (RegisterBranchDto newBranch) =>
            {
                var exists = branches.Exists(r => r.Name == newBranch.Name || r.Email == newBranch.Email || r.CNPJ == newBranch.Cnpj);
                if (!exists)
                {
                    var createdBranch = branchServices.Register(newBranch);
                    return Results.CreatedAtRoute(GetNameBranchEndpoint, new { id = createdBranch.Id }, createdBranch);
                }
                else
                {
                    return Results.BadRequest(new { success = false, message = "Name, Email, CNPJ, or Domain already used" });
                }
            });

            // PUT /branch/{id}
            group.MapPut("/{id}", (uint id, UpdateBranchDto updateBranch) =>
            {
                var index = branches.FindIndex(Branch => Branch.Id == id);

                if (index == -1)
                {
                    return Results.NotFound();
                }

                branches[index] = new Branch(
                    id,
                    updateBranch.Name,
                    updateBranch.Email,
                    updateBranch.Password,
                    updateBranch.Address,
                    updateBranch.CreationDate,
                    updateBranch.Cnpj);

                return Results.NoContent();
            });

            // DELETE /branch/{id}
            group.MapDelete("/{id}", (int id) =>
            {
                bool deleted = branchServices.Delete(id); // Corrigido para usar um método que retorna um booleano
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
