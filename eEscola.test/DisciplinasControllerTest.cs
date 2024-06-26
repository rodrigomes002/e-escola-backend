using eEscola.API.Controllers;
using eEscola.Test.Entities;
using eEscola.Test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.Test
{
    public class DisciplinasControllerTest
    {
        [Fact]
        public async Task Get_Sucesso_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .ProcurarDisplina();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var result = await controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Sucesso_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .CadastroDisciplina_Sucesso();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var disciplina = DisciplinaMock.Disciplina();

            var result = await controller.Post(disciplina);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Falha_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .CadastroDisciplina_Falha();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var disciplina = DisciplinaMock.Disciplina();

            var result = await controller.Post(disciplina);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Sucesso_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .ProcurarDisciplinaPorId_Sucesso()
                                                .EditarDisciplina_Sucesso();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var result = await controller.Put(1, DisciplinaMock.Disciplina());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_Falha_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .ProcurarDisciplinaPorId_Sucesso()
                                                .EditarDisciplina_Falha();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var result = await controller.Put(1, DisciplinaMock.Disciplina());
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_Sucesso_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .ProcurarDisciplinaPorId_Sucesso()
                                                .DeletarDisciplina_Sucesso();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Falha_Test()
        {
            var disciplinaRepositoryMock = new DisciplinaRepositoryMock()
                                                .ProcurarDisciplinaPorId_Falha()
                                                .DeletarDisciplina_Falha();
            var controller = new DisciplinasController(disciplinaRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
