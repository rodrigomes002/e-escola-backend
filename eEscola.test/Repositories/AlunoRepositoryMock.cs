using eEscola.API.Interfaces;
using eEscola.API.Models;
using Moq;

namespace eEscola.test.Repositories
{
    public class AlunoRepositoryMock : Mock<IAlunoRepository>
    {
        public AlunoRepositoryMock ProcurarAluno()
        {
            Setup(repository => repository.GetAll())
                .ReturnsAsync(AlunoMock.AlunoList())
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock CadastroAluno_Sucesso()
        {
            Setup(repository => repository.Add(It.IsAny<Aluno>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock CadastroAluno_Falha()
        {
            Setup(repository => repository.Add(It.IsAny<Aluno>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock EditarAluno_Sucesso()
        {
            Setup(repository => repository.Edit(It.IsAny<Aluno>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock EditarAluno_Falha()
        {
            Setup(repository => repository.Edit(It.IsAny<Aluno>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock DeletarAluno_Sucesso()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock DeletarAluno_Falha()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock ProcurarAlunoPorId_Sucesso()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(AlunoMock.Aluno)
                .Verifiable();

            return this;
        }

        public AlunoRepositoryMock ProcurarAlunoPorId_Falha()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(AlunoMock.AlunoNull)
                .Verifiable();

            return this;
        }
    }
}
