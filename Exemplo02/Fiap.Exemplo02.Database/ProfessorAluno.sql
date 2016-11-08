CREATE TABLE [dbo].[ProfessorAluno]
(
	[ProfessorId] INT NOT NULL , 
    [AlunoId] INT NOT NULL, 
    PRIMARY KEY ([ProfessorId], [AlunoId]), 
    CONSTRAINT [FK_ProfessorAluno_Professor] FOREIGN KEY ([ProfessorId]) REFERENCES [Professor]([Id]), 
    CONSTRAINT [FK_ProfessorAluno_ToAluno] FOREIGN KEY ([AlunoId]) REFERENCES [Aluno]([Id])
)
