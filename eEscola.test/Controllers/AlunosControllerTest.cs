using eEscola.API.Controllers;
using eEscola.test.Entities;
using eEscola.test.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace eEscola.test.Controllers
{
    public class AlunosControllerTest
    {
        [Fact]
        public async Task Get_Sucesso_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .ProcurarAluno();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var result = await controller.Get();
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Sucesso_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                           .CadastroAluno_Sucesso();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var aluno = AlunoMock.Aluno();

            var result = await controller.Post(aluno);

            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_Falha_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .CadastroAluno_Falha();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var aluno = AlunoMock.Aluno();

            var result = await controller.Post(aluno);
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_Sucesso_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .ProcurarAlunoPorId_Sucesso()
                                            .EditarAluno_Sucesso();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var result = await controller.Put(1, AlunoMock.Aluno());
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Put_Falha_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .ProcurarAlunoPorId_Sucesso()
                                            .EditarAluno_Falha();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var result = await controller.Put(1, AlunoMock.Aluno());
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_Sucesso_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .ProcurarAlunoPorId_Sucesso()
                                            .DeletarAluno_Sucesso();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Delete_Falha_Test()
        {
            var alunoRepositoryMock = new AlunoRepositoryMock()
                                            .ProcurarAlunoPorId_Falha()
                                            .DeletarAluno_Falha();
            var controller = new AlunosController(alunoRepositoryMock.Object);

            var result = await controller.Delete(1);
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
