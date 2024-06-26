using eEscola.API.Interfaces;
using eEscola.API.Models;
using eEscola.test.Entities;
using Moq;

namespace eEscola.test.Repositories
{
    public class ProfessorRepositoryMock : Mock<IProfessorRepository>
    {
        public ProfessorRepositoryMock ProcurarProfessor()
        {
            Setup(repository => repository.GetAll())
                .ReturnsAsync(ProfessorMock.ProfessorList)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock CadastrarProfessor_Sucesso()
        {
            Setup(repository => repository.Add(It.IsAny<Professor>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock CadastrarProfessor_Falha()
        {
            Setup(repository => repository.Add(It.IsAny<Professor>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock EditarProfessor_Sucesso()
        {
            Setup(repository => repository.Edit(It.IsAny<Professor>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock EditarProfessor_Falha()
        {
            Setup(repository => repository.Edit(It.IsAny<Professor>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock DeletarProfessor_Sucesso()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock DeletarProfessor_Falha()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock ProcurarPorIdProfessor_Sucesso()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProfessorMock.Professor)
                .Verifiable();

            return this;
        }

        public ProfessorRepositoryMock ProcurarPorIdProfessor_Falha()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(ProfessorMock.ProfessorNull)
                .Verifiable();

            return this;
        }
    }
}
