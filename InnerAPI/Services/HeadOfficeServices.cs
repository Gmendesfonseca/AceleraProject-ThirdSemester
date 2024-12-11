using InnerAPI.Dtos.HeadOffice;
using InnerAPI.Dtos;
using InnerAPI.Dtos.Login;
using InnerAPI.Models;
using InnerAPI.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InnerAPI.Services
{
    public class HeadOfficeServices
    {
        List<HeadOffice> headOffices;
        List<Branch> globalBranchesList;

        public HeadOfficeServices(SharedService _sharedService)
        {
            headOffices = _sharedService.HeadOffices;
            globalBranchesList = _sharedService.Branches;
        }

        public HeadOffice Register(RegisterHeadOfficeDto register)
        {
            uint id = (uint)headOffices.Count + 1;
            string name = register.Name;
            string email = register.Email;
            string password = register.Password;
            string domain = register.Domain;
            string cnpj = register.CNPJ;
            string image = "caminho/para/imagem.jpg";
            string about = register.About;
            string address = register.Address;
            DateOnly creationDate = DateOnly.FromDateTime(DateTime.Now); // Exemplo usando a data atual

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Email inválido.");

            var existingUser = headOffices.Exists(r => r.Name == register.Name || r.Email == register.Email || r._cnpj == register.CNPJ || r._domain == register.Domain);
            if (existingUser)
            {
                throw new ArgumentException("Este email já está sendo usado por outro usuário.");
            }

            HeadOffice newHeadOffice = new HeadOffice(id, name, email, password, image, about, address, creationDate, cnpj, domain);

            headOffices.Add(newHeadOffice);

            return newHeadOffice;

            headOffices.Add(newHeadOffice);

            return newHeadOffice;
        }

        public HeadOffice Login(LoginDto user)
        {
            string email = user.Email;
            string password = user.Password;

            HeadOffice headOffice = headOffices.FirstOrDefault(i => i.Email == user.Email);

            Email Email = new Email();
            if (!Email.IsValid(email))
                throw new ArgumentException("Email inválido.");

            if (headOffice == null)
                throw new ArgumentException("Usuário não encontrado.");

            if (headOffice.Password != password)
                throw new ArgumentException("Senha incorreta.");

            return headOffice;
        }

        public HeadOffice Update(int id, RegisterHeadOfficeDto register)
        {
            HeadOffice headOffice = headOffices.FirstOrDefault(i => i.Id == id);

            if (headOffice == null)
                throw new ArgumentException("Usuário não encontrado.");

            headOffice.Name = register.Name;
            headOffice.Email = register.Email;
            headOffice.Password = register.Password;
            headOffice.Domain = register.Domain;
            headOffice._cnpj = register.CNPJ;

            return headOffice;
        }

        public List<Branch> Branches(uint id) // Alterado o nome do parâmetro para evitar conflito
        {
            List<Branch> newBranchsList = new List<Branch>();
            var headOffice = headOffices.FirstOrDefault(i => i.Id == id);
            if (headOffice == null) return newBranchsList;

            List<uint> branches = headOffice.Branches;

            foreach (uint branchId in branches)
            {
                var branch = globalBranchesList.FirstOrDefault(i => i.Id == branchId);
                if (branch != null)
                    newBranchsList.Add(branch);
            }

            return newBranchsList;
        }

        public bool Delete(int id)
        {
            headOffices.RemoveAll(usuario => usuario.Id == id);
            return true;
        }

        public void SuspenderAcesso()
        {
            //implementação futura
        }
    }
}
