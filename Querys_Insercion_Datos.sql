
select * from Franquicia;

insert into Franquicia values('Metro','https://www.metro.pe/','/api/metroproducto/','/img/metro.jpg'),
							 ('Tottus','https://www.tottus.com.pe/tottus/','/api/tottusproducto/','/img/tottus.jpg'),
							 ('Plaza Vea','https://www.plazavea.com.pe/','/api/plazaveaproducto/','/img/plazavea.jpg'),
							 ('Wong','https://www.wong.pe/','/api/wongproducto/','/img/wong.jpg');

select * from Sede;

insert into Sede values('Av. Universitaria',1,12.3234,15.3242),
					   ('Av. Asuncion',2,14.1234,15.323),
					   ('Av. Pascana',3,15.342,12.2344),
					   ('Av. Wong',4,2.343,12.535);


select * from Marca;

insert into Marca values('Gloria'),
						('LG'),
						('Samsung'),
						('San Luis'),
						('San Mateo');

select * from Categoria;

insert into Categoria values('Lacteos',null);
insert into Categoria values('Leche',1);
insert into Categoria values('Yogurt',1);


select * from Usuario;

insert into Usuario values('fernando1','$2dfkm$%2','%$#"#$!','fernando@gmail.com',1),
					      ('justin2','#&%$#GFG','(/%%$#FGA','justin@gmail.com',1),
						  ('alexia','4$#%GF','%#%HT','alexia@gmail.com',1),
						  ('jorge','ad$%#G','$##GD','jorge@gmail.com',1),
						  ('diego','DSF#R"T','AT#$GD','diego@gmail.com',1);

select * from Direccion;

insert into Direccion values(1,12.4335,13.2355,'Av. Asuncion'),
							(2,16.235,32.3555,'A la espalda del burger king'),
							(3,2.33434,24.3455,'AEA'),
							(4,5.23425,35.335,'Los Olivos'),
							(5,4.352,3.435,'Av. Marina');

select * from Marca;
select * from Categoria;
select * from Producto;


insert into Producto values(2,1,'Leche Evaporada','paquete',4,500,'g','Leche evaporada','/img/lecheevaporada.jpg'),
						   (3,1,'Yogurt Fresa','botella',1,1000,'ml','Yogurt de sabor fresa','/img/yogurtfresa.jppg');

select * from Transaccion;

insert into Transaccion values('123456'),
							  ('789101');


select * from Usuario;
select * from Sede;
select * from Transaccion;
select * from pedido;

insert into Pedido values(1,3,'Comprando','20190608','Calle Quito 173',1,300,10,30),
						 (2,2,'Entregado','20190604','Av. Asuncion',2,500,20,50);

select * from DetallePedido;
select * from Producto;

insert into DetallePedido values(1,1,50,2),
								(1,2,100,2),
								(2,1,50,6),
								(2,2,100,2);

select * from Cupon;
select * from pedido;
insert into Cupon values('123456','20190607','20190609',1,0.10,1),
				  ('654321','20190607','20190609',1,0.10,2);

select * from usuario;
select * from producto;
select * from Cupon;
select * from CarritoItem;


insert into CarritoItem values(1,1,10),
							  (1,2,30),
							  (2,1,10),
							  (2,2,20),
							  (3,1,10),
							  (3,2,20);


select * from ProductoFranquicia;
select * from Producto;
select * from Franquicia;

insert into ProductoFranquicia values(1,2,'44'),
									 (2,2,'45'),
									 (1,1,'56'),
									 (2,1,'54'),
									 (1,3,'34'),
									 (2,3,'45'),
									 (1,4,'35'),
									 (2,4,'56');