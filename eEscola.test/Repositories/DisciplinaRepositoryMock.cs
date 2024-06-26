using eEscola.API.Interfaces;
using eEscola.API.Models;
using eEscola.test.Entities;
using Moq;

namespace eEscola.test.Repositories
{
    public class DisciplinaRepositoryMock : Mock<IDisciplinaRepository>
    {
        public DisciplinaRepositoryMock ProcurarDisplina()
        {
            Setup(repository => repository.GetAll())
                .ReturnsAsync(DisciplinaMock.DisciplinaList())
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock CadastroDisciplina_Sucesso()
        {
            Setup(repository => repository.Add(It.IsAny<Disciplina>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock CadastroDisciplina_Falha()
        {
            Setup(repository => repository.Add(It.IsAny<Disciplina>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock EditarDisciplina_Sucesso()
        {
            Setup(repository => repository.Edit(It.IsAny<Disciplina>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock EditarDisciplina_Falha()
        {
            Setup(repository => repository.Edit(It.IsAny<Disciplina>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock DeletarDisciplina_Sucesso()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(true)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock DeletarDisciplina_Falha()
        {
            Setup(repository => repository.Delete(It.IsAny<int>()))
                .ReturnsAsync(false)
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock ProcurarDisciplinaPorId_Sucesso()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(DisciplinaMock.Disciplina())
                .Verifiable();

            return this;
        }

        public DisciplinaRepositoryMock ProcurarDisciplinaPorId_Falha()
        {
            Setup(repository => repository.GetById(It.IsAny<int>()))
                .ReturnsAsync(DisciplinaMock.DisciplinaNull())
                .Verifiable();

            return this;
        }
    }
}
