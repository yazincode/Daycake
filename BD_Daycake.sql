drop database if exists daycake;
CREATE DATABASE Daycake;
 
USE Daycake;
 
CREATE TABLE Usuario(
	idUsuario int auto_increment primary key,
	nome varchar(150) not null,
	login varchar(50) not null,
	senha varchar(100) not null,
	cargo varchar(50) not null,
	ativo boolean default true
);
 
INSERT INTO Usuario(nome, login, senha, cargo, ativo) VALUES
('Juliana Ferreira', 'juliana.f', 'julia123', 'Confeiteira', 1),
('Carlos Andrade', 'carlos.a', 'carlos321', 'Caixa', 1),
('Mariana Costa', 'mari.costa', 'mari2025', 'Atendente', 1);
 
Select * from Usuario;
 
CREATE TABLE Cliente(
	idCliente int auto_increment primary key,
	nome varchar(150) not null,
	telefone varchar(20) not null,
	email varchar(100),
	endereco varchar(100),
    numero varchar(10),
    bairro varchar(50),
    data_cadastro varchar(60)
);
 
INSERT INTO Cliente (nome, telefone, email, endereco, numero, bairro, data_cadastro) VALUES
('Ana Silva', '11999990001', 'ana@email.com', 'Rua das Rosas', '123', 'Centro', '2025-05-01'),
('Carlos Souza', '11999990002', 'carlos@email.com', 'Rua dos Lírios', '456', 'Jardins', '2025-05-02'),
('Beatriz Lima', '11999990003', 'bia@email.com', 'Av. Brasil', '789', 'Morumbi', '2025-05-03'),
('Lucas Pereira', '11999990004', 'lucas@email.com', 'Rua Verde', '321', 'Liberdade', '2025-05-04'),
('Fernanda Costa', '11999990005', 'fernanda@email.com', 'Rua Azul', '654', 'Bela Vista', '2025-05-05'),
('Ricardo Alves', '11999990006', 'ricardo@email.com', 'Av. Paulista', '987', 'Paulista', '2025-05-06'),
('Juliana Rocha', '11999990007', 'juliana@email.com', 'Rua Branca', '159', 'Pinheiros', '2025-05-07'),
('Gabriel Monteiro', '11999990008', 'gabriel@email.com', 'Rua Preta', '753', 'Vila Mariana', '2025-05-08'),
('Isabela Martins', '11999990009', 'isabela@email.com', 'Rua Cinza', '951', 'Tatuapé', '2025-05-09'),
('Pedro Henrique', '11999990010', 'pedro@email.com', 'Av. Amarela', '852', 'Mooca', '2025-05-10');
 
 
Select * from Cliente;
 
CREATE TABLE Produto(
	idProduto int(50) auto_increment primary key,
	nome varchar(150) not null,
	descricao varchar(255) not null,
	preco varchar(5) not null,
	tempo_preparo varchar(20),
	status varchar(11) not null,
    qtd int not null default 1
);
 
INSERT INTO Produto (nome, descricao, preco, tempo_preparo, status, qtd) VALUES
('Bolo de Chocolate', 'Bolo com recheio de brigadeiro', '50', '02:00', 'Ativo', 5),
('Torta de Limão', 'Torta gelada com cobertura de merengue', '45', '01:30', 'Ativo', 3),
('Cupcake de Baunilha', 'Cupcake com cobertura de chantilly', '8', '00:40', 'Ativo', 12),
('Brigadeiro Gourmet', 'Brigadeiro feito com chocolate belga', '3', '00:30', 'Ativo', 30),
('Bolo Red Velvet', 'Clássico bolo americano', '60', '02:30', 'Ativo', 2),
('Torta de Morango', 'Torta com geleia e pedaços de morango', '48', '01:40', 'Ativo', 4),
('Brownie', 'Brownie com pedaços de nozes', '6', '00:50', 'Ativo', 10),
('Bolo de Cenoura', 'Com cobertura de chocolate', '40', '01:20', 'Ativo', 6),
('Pudim de Leite', 'Clássico pudim com calda de caramelo', '35', '03:00', 'Ativo', 3),
('Mini Cheesecake', 'Cheesecake com calda de frutas vermelhas', '12', '01:00', 'Ativo', 7);
 
Select * from Produto;
 
CREATE TABLE Pedido(
	idPedido int auto_increment primary key, -- IDPEDIDO
	clienteid int(50) not null,
    nomeCliente varchar(200) not null,
	data_pedido varchar(100) not null,
	data_entrega varchar(150) not null,
	valor decimal(10,2) not null,
	tipo_de_doce varchar(500) not null,
	descricao varchar(500) not null,
	forma_pagamento varchar(100) not null,
	status varchar(100) not null,
 
	FOREIGN KEY (clienteid)
	REFERENCES Cliente(idCliente)
);
 
INSERT INTO Pedido (clienteid, nomeCliente, data_pedido, data_entrega, valor, tipo_de_doce, descricao, forma_pagamento, status) VALUES
(1, 'Ana Silva', '2025-05-01', '2025-05-05', 120.00, 'Bolo de Chocolate', 'Aniversário infantil', 'Pix', 'Em andamento'),
(2, 'Carlos Souza', '2025-05-02', '2025-05-06', 90.00, 'Torta de Limão', 'Encomenda para evento', 'Cartão de Crédito', 'Finalizado'),
(3, 'Beatriz Lima', '2025-05-03', '2025-05-08', 36.00, 'Brigadeiro Gourmet', 'Para presentear', 'Dinheiro', 'Entregue'),
(4, 'Lucas Pereira', '2025-05-04', '2025-05-09', 60.00, 'Cupcake de Baunilha', 'Festa de noivado', 'Cartão de Débito', 'Cancelado'),
(5, 'Fernanda Costa', '2025-05-05', '2025-05-10', 135.00, 'Bolo Red Velvet', 'Encomenda especial', 'Pix', 'Finalizado'),
(6, 'Ricardo Alves', '2025-05-06', '2025-05-11', 48.00, 'Torta de Morango', 'Sobremesa de fim de semana', 'Dinheiro', 'Em andamento'),
(7, 'Juliana Rocha', '2025-05-07', '2025-05-12', 60.00, 'Brownie', 'Reunião corporativa', 'Cartão de Crédito', 'Entregue'),
(8, 'Gabriel Monteiro', '2025-05-08', '2025-05-13', 40.00, 'Bolo de Cenoura', 'Presente para avó', 'Pix', 'Finalizado'),
(9, 'Isabela Martins', '2025-05-09', '2025-05-14', 35.00, 'Pudim de Leite', 'Sobremesa de domingo', 'Dinheiro', 'Em andamento'),
(10, 'Pedro Henrique', '2025-05-10', '2025-05-15', 72.00, 'Mini Cheesecake', 'Evento corporativo', 'Cartão de Débito', 'Cancelado');
 
Select * from Pedido;
 
SELECT cliente.idcliente, cliente.nome, pedido.idpedido, pedido.tipo_de_doce, pedido.data_pedido, pedido.status
FROM Cliente
INNER JOIN pedido ON cliente.idcliente = pedido.clienteid;
 
 
-- SELECT PARA RELATORIOS
 
-- Produto mais vendido
select tipo_de_doce,
count(*) as quantidade_vendas,
sum(cast(valor as decimal(10,2))) as total_arrecadado
from Pedido
where status in ('Entregue', 'Finalizado')
group by tipo_de_doce
order by quantidade_vendas desc;
 
-- Clientes recorrentes
select
	c.idCliente,
    c.nome,
    count(p.idPedido) as total_pedidos
from Cliente c
join Pedido p on c.idCliente = p.clienteid
where p.status in ('Entregue', 'Finalizado')
group by c.idCliente, c.nome
having total_pedidos > 1;
 
-- Número de clientes atendidos
select
	count(distinct clienteid) as clientes_atendidos,
    date_format(str_to_date(data_pedido, '%Y-%m-%d'),'%Y-%m') as mes
from Pedido
where status in ('Entregue', 'Finalizado')
group by mes;
 
-- Receita total
SELECT
    YEAR(STR_TO_DATE(data_pedido, '%Y-%m-%d')) AS ano,
    WEEK(STR_TO_DATE(data_pedido, '%Y-%m-%d'), 1) AS semana,
    SUM(CAST(valor AS DECIMAL(10,2))) AS receita_semanal
FROM Pedido
WHERE status IN ('Entregue', 'Finalizado')
GROUP BY ano, semana
ORDER BY ano, semana;
 
-- Produto mais vendidos
SELECT
    tipo_de_doce,
    COUNT(*) AS quantidade_vendas,
    SUM(CAST(valor AS DECIMAL(10,2))) AS total_arrecadado
FROM Pedido
WHERE status IN ('Entregue', 'Finalizado')
GROUP BY tipo_de_doce
ORDER BY quantidade_vendas DESC;
 
-- Comparativo com mês anterior
SELECT
    DATE_FORMAT(STR_TO_DATE(data_pedido, '%Y-%m-%d'), '%Y-%m') AS mes,
    SUM(CAST(valor AS DECIMAL(10,2))) AS receita
FROM Pedido
WHERE status IN ('Entregue', 'Finalizado')
GROUP BY mes
ORDER BY mes DESC
LIMIT 2;