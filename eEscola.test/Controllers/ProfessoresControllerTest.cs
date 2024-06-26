using eEscola.API.Controllers;
using eEscola.Test.Entities;
using eEscola.Test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.Test.Controllers
{
    public class ProfessoresControllerTest
    {
        [Fact]
        public async Task Get_Sucesso_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .ProcurarProfessor();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var result = await controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Sucesso_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .CadastrarProfessor_Sucesso();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var professor = ProfessorMock.Professor();

            var result = await controller.Post(professor);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Falha_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .CadastrarProfessor_Falha();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var professor = ProfessorMock.Professor();

            var result = await controller.Post(professor);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Sucesso_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .ProcurarPorIdProfessor_Sucesso()
                                                .EditarProfessor_Sucesso();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var result = await controller.Put(1, ProfessorMock.Professor());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_Falha_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .ProcurarPorIdProfessor_Sucesso()
                                                .EditarProfessor_Falha();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var result = await controller.Put(1, ProfessorMock.Professor());
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_Sucesso_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .ProcurarPorIdProfessor_Sucesso()
                                                .DeletarProfessor_Sucesso();
            var controller = new ProfessoresController (professorRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Falha_Test()
        {
            var professorRepositoryMock = new ProfessorRepositoryMock()
                                                .ProcurarPorIdProfessor_Falha()
                                                .DeletarProfessor_Falha();
            var controller = new ProfessoresController(professorRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
