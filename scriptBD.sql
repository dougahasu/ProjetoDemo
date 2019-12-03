CREATE TABLE Estado
(
    IdEstado INTEGER
	IdIbge INTEGER,
	Sigla VARCHAR2(2),
	Nome VARCHAR2(50)
);

ALTER TABLE Estado ADD CONSTRAINT IdEstadoPK PRIMARY KEY (IdEstado);

CREATE TABLE Cliente
(
	IdCliente INTEGER, 
	Nome VARCHAR2(30),
	IdEstado INTEGER,
	Celular VARCHAR2(15)
);

ALTER TABLE Cliente ADD CONSTRAINT IdClientePK PRIMARY KEY (IdCliente);

CREATE TABLE TipoFinanciamento
(
    IdTipoFinanciamento INTEGER, 
    Descricao VARCHAR2
);

ALTER TABLE TipoFinanciamento ADD CONSTRAINT IdTipoFinanciamentoPK PRIMARY KEY (IdTipoFinanciamento);

CREATE TABLE Financiamento
(
	IdFinanciamento INTEGER,
	IdCliente INTEGER,
	TipoFinanciamento VARCHAR2(50),
	ValorTotal NUMBER(12,2),
	DataVencto DATE	
);

ALTER TABLE Financiamento ADD CONSTRAINT IdFinanciamentoPK PRIMARY KEY (IdFinanciamento);

CREATE TABLE Parcela
(
	IdParcela INTEGER,
	IdFinanciamento INTEGER,
	NumeroParcela INTEGER,
	ValorParcela NUMBER(12,2),
	DataVencto DATE,
	DataPagto DATE
);

ALTER TABLE Parcela ADD CONSTRAINT IdParcelaPK PRIMARY KEY (IdParcela);

select Cliente.Nome
from Cliente 
left outer join Estado on Estado.IdEstado = Cliente.IdEstado
left outer join Financiamento on Financiamento.IdCliente = Cliente.IdCliente
left outer join Parcela on Parcela.IdFinanciamento = Financiamento.IdFinanciamento
where Estado.Sigla = 'SP'
and (Parcela.NumeroParcela * 0.6) < 
(
    select count(*) total 
    from Parcela 
    where Parcela.IdFinanciamento = Financiamento.IdFinanciamento
    and Parcela.DataPagto is not null
) 

select Cliente.Nome 
from Cliente
left outer join Financiamento on Cliente.IdCliente = Financiamento.IdCliente
left outer join Parcela on Parcela.IdFinanciamento = Financiamento.IdFinanciamento
where DataPagto.DataPagto is null and (CURRENT_DATE + 5) > Parcela.DataPagto and ROWNUM <= 4

select Cliente.Nome
from Cliente
left outer join Financiamento on Financiamento.IdCliente = Cliente.IdCliente
where Financiamento.ValorTotal > 10000
and (
        select count(*) total
        from Parcela
        where Parcela.IdFinanciamento = Financiamento.IdFinanciamento
        and DateAdd(Parcela.DataPagto, '1', 10) > Parcela.DataVencto
    )  > 1