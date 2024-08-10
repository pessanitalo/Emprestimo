

select * from Cliente
select * from Emprestimo

DELETE FROM Emprestimo where EmprestimoId = 7

create table Cliente
(
	ClienteId int primary key identity,
	Nome varchar(50) not null,
	Idade int not null,
	Cpf varchar(11) not null,
	Score float not null,
	SaldoAtual decimal
);



create table Emprestimo
(
	EmprestimoId int primary key identity,
	ClienteId int,
	ValorEmprestimo decimal not null,
	QuantidadeParcelas int not null,
	ValorDaParcela decimal not null,
	valorTotal decimal not null,
	DataAquisicaoEmprestimo date
	constraint fk_clienteid_cliente foreign key (ClienteId)
	references Cliente
	
); 

create table BoletoEmprestimo
(
	BoletoId int primary key identity,
	EmprestimoId int,
	NumeroParcela int not null,
	ValorDaParcela decimal not null,
	DataDePagamento Date not null,
	constraint fk_EmprestimoId_cliente foreign key (EmprestimoId)
	references Emprestimo
);

