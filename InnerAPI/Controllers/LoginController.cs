using InnerAPI.Dtos.Login;
using InnerAPI.Models;
using InnerAPI.Services;
using InnerAPI.Utils;
using System.Xml.Linq;
using System;

namespace InnerAPI.Controllers
{
    public static class LoginController
    {
        public static RouteGroupBuilder MapLoginEndpoint(this WebApplication app, SharedService sharedService)
        {
            var group = app.MapGroup("login").WithParameterValidation();

            //POST /login/headoffice
            _ = group.MapPost("/headoffice", (LoginDto login) =>
            {
                HeadOfficeServices headOfficeServices = new HeadOfficeServices(sharedService);
                var headOffice = headOfficeServices.Login(login);

                if (headOffice.Login(login))
                {
                    // Se o login for bem-sucedido, retorne OK
                    return Results.Ok(new
                    {
                        success = true,
                        message = "Login successful",
                        user = new
                        {
                            id = headOffice.Id,
                            name = headOffice.Name,
                            email = headOffice.Email,
                            avatar = headOffice.Avatar,
                            institution = headOffice.Name,               
                            about = headOffice.About,
                            branches = headOfficeServices.Branches(headOffice.Id),
                        }
                    }); ;
                }
                else
                {
                    // Se o login falhar, retorne BadRequest
                    return Results.BadRequest(new { success = false, message = "User not found" });
                }
            });

            //POST /login/branch
            group.MapPost("/branch", (LoginDto login) =>
            {
                BranchServices branchServices = new(sharedService);

                var branch = branchServices.Login(login);

                if (branch == null)
                {
                    return Results.BadRequest(new { success = false, message = "User not found" });
                }
                return Results.Ok(new
                {
                    success = true,
                    message = "Login successful",
                    user = new
                    {
                        id = branch.Id,
                        name = branch.Name,
                        email = branch.Email,
                        avatar = branch.Avatar,
                        about = branch.About,
                        professors = branchServices.Professors(branch.Id),
                        students = branchServices.Students(branch.Id),
                        courses = branch.Courses,

                    }
                });
            });

            //POST /login/professor
            group.MapPost("/professor", (LoginDto login) =>
            {
                ProfessorServices professorServices = new(sharedService);
                var professor = professorServices.Login(login);
                if (professor == null)
                {
                    return Results.BadRequest(new { success = false, message = "User not found" });
                }
                return Results.Ok(new
                {
                    success = true,
                    message = "Login successful",
                    user = new
                    {
                        id = professor.Id,
                        name = professor.Name,
                        email = professor.Email,
                        avatar = professor.Avatar,
                        about = professor.About,
                        institution = professor.Institution,
                        institutionId = professor.InstitutionId,
                        posts = professorServices.Posts(professor.InstitutionId),
                        chats = professor.Chats,
                        friends = professorServices.Friends(professor.InstitutionId),
                    }
                });
            });

            //POST /login/student
            group.MapPost("/student", (LoginDto login) =>
            {
                StudentServices studentServices = new(sharedService);
                var student = studentServices.Login(login);
                if (student == null)
                {
                    return Results.BadRequest(new { success = false, message = "User not found" });
                }
                return Results.Ok(new
                {
                    success = true,
                    message = "Login successful",
                    user = new
                    {
                        id = student.Id,
                        name = student.Name,
                        email = student.Email,
                        avatar = student.Avatar,
                        about = student.About,
                        institution = student.Institution,
                        institutionId = student.InstitutionId,
                        posts = studentServices.Posts(student.InstitutionId),
                        chats = student.Chats,
                        friends = student.Friends,
                    }
                });
            });

            return group;
        }
    }
}
