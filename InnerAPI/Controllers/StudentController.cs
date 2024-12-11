using InnerAPI.Models;
using InnerAPI.Services;
using InnerAPI.Dtos.Login;
using Microsoft.AspNetCore.Mvc;
using InnerAPI.Dtos.Aluno;

namespace InnerAPI.Controllers
{
    public static class StudentController
    {
        public static RouteGroupBuilder MapStudentEndpoint(this WebApplication app, SharedService sharedServices)
        {
            StudentServices studentServices = new StudentServices(sharedServices);
            var group = app.MapGroup("student").WithParameterValidation();

            // GET /student/{id}
            group.MapGet("/{id}", (uint id) =>
            {
                return Results.Ok(studentServices.GetStudents(id).FirstOrDefault(s => s == id));
            });

            // POST /student/register
            group.MapPost("/register", (RegisterStudentDto newStudent) =>
            {
                Student student = studentServices.Register(newStudent);

                return Results.Created($"/student/{student.Id}", student);
            });

            // PUT /student/{id}
            group.MapPut("/{id}", (int id, Student updatedStudent) =>
            {
                var result = studentServices.Update(id, updatedStudent);
                if (result == null)
                {
                    return Results.NotFound();
                }
                return Results.Ok(result);
            });

            // DELETE /student/{id}
            group.MapDelete("/{id}", (int id) =>
            {
                bool deleted = studentServices.Delete(id);
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
