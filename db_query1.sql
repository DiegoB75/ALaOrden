insert into Marca(nombre) values('Coca Cola'),
('Nabisco'),
('Gloria'),
('Pringles'),
('Aje'),
('Molitalia'),
('Costeño'),
('Wawasana'),
('Kelloggs'),
('Costa'),
('Pepsico'),
('Donofrio');


	insert into Categoria(nombre, idcategoriapadre) values('Bebidas', null),
	('Abarrotes', null),
	('Lacteos', null),
	('Agua', '1'),
	('Refrescos gaseosos', '1'),
	('Cereales', '2'),
	('Pastas', '2'),
	('Arroz', '2'),
	('Infusiones', '2'),
	('Galletas', '2'),
	('Snacks', '2'),
	('Leches', '3'),
	('Helados', '3'),
	('Cuidado personal', null),
	('Frescos', null),
	('Limpieza', null),
	('Mascotas', null),
	('Niños', null),
	('Hogar', null),
	('Cuidado de la piel', '14'),
	('Afeitado y depilacion', '14'),
	('Congelados', '15'),
	('Frutas y verduras', '15'),
	('Accesorios de limpieza', '16'),
	('Ambientales', '16'),
	('Accesorios para mascotas', '17'),
	('Alimento para mascotas', '17'),
	('Accesorio para bebe', '18'),
	('Alimentos infantiles', '18'),
	('Baterias', '19'),
	('Iluminacion', '19');


	insert into Usuario(email,emailvalidado,HashContrasena,apodo,  sal) values
	('alexia@hotmail.com',1,'u201714092','Alexia',  'salt'),
	( 'diego@hotmail.com',1,'u201616874','Diego',  'salt'),
	('fernando@hotmail.com',1,'u201712916','Fernando',  'salt'),
	('jorge@hotmail.com',1,'u201620280','Jorge',  'salt'),
	('marco@hotmail.com',1,'u20171b533','Marco',  'salt');

	insert into Franquicia(apiUrl, logo , nombre, webUrl) values
	('api/WongProducto',  'wong.png','Wong', 'www.wong.com'),
		('api/MetroProducto',  'metro.png','Metro', 'www.metro.com'),
		('api/PlazaVea','Plaza Vea',  'plazavea.png', 'www.plazavea.com'),
		('api/TottusProducto',  'tottus.png','Tottus', 'www.tottus.com');

	insert into Direccion( Descripcion,latitud , longitud, IdUsuario) values
	('Av. Universitaria 3, Pueblo Libre 15084',  '-12.077053', '-77.081605' , '1'),
		('Av. Sta. Cruz 771, Miraflores 15074',  '-12.110091', '-77.036466', '1' ),
		('Av. de la Marina 2500, San Miguel 15088',  '-12.076645' , '-77.089390', '2'),
		('Av Alfredo Mendiola 3900, Independencia 15311',  '-11.988214', '-77.063322', '2' ),
		('Av. Arequipa 2250, Lince 15046',  '-12.086598', '-77.034525' , '3'),
		('Av Alfredo Mendiola 3900, Independencia 15311',  '-11.989074', '-77.063365' , '3'),
		('San Miguel 15087',  '-12.079253' , '-77.088456', '4'),
		('Zinc, Los Olivos 15311',  '-11.965446', '-77.066993', '4');

		insert into sede(Direccion, IdFranquicia, longitud, latitud) values
		('Av. Universitaria 3, Pueblo Libre 15084', '1', '-77.081605', '-12.077053'),
		('Av. Sta. Cruz 771, Miraflores 15074', '1', '-77.036466', '-12.110091'),
		('Av. de la Marina 2500, San Miguel 15088', '2', '-77.089390', '-12.076645'),
		('Av Alfredo Mendiola 3900, Independencia 15311', '2', '-77.063322', '-11.988214'),
		('Av. Arequipa 2250, Lince 15046', '3', '-77.034525', '-12.086598'),
		('Av Alfredo Mendiola 3900, Independencia 15311', '3', '-77.063365', '-11.989074'),
		('San Miguel 15087', '4', '-77.088456', '-12.079253'),
		('Zinc, Los Olivos 15311', '4', '-77.066993', '-11.965446');

	insert into Producto(IdCategoria, IdMarca, Nombre, Presentacion, cantidad, Magnitud, Unidad, Descripcion, Imagen) values

	('5', '1', 'Sprite', 'botella', '1', '625', 'ml', 'Gaseosa blanca sabor a limón', 'sprite.png'),
		('4', '1', 'San Luis', 'botella', '6', '625', 'ml', 'Six pack de agua con sabor a metal', 'sixsanluis.png'),
		('10', '2', 'Oreo', 'paquete', '1', '18', 'g', 'Galleta de chocolote con relleno', 'oreo.png' ),
		('10', '2', 'Oreo Fresa', 'paquete', '6', '18', 'g', 'Six pack de galleta de chocolote con relleno', 'sixoreofresa.png' ),
		('12', '3', 'Leche Evaporada', 'tarro', '1', '400', 'g', 'Tarro de leche evaporada', 'gloria.png' ),
		('12', '3', 'Tetrapack', 'caja', '1', '1', 'l', 'Tetrapack de leche', 'gloriatp.png' ),
		('11', '4', 'Pringles BBQ', 'lata', '1', '168', 'g', 'Lata de pringles con sabor a BBQ', 'pringlesbbq.png' ),
		('11', '4', 'Pringles Honey Mustard', 'lata', '1', '168', 'g', 'Lata de pringles con sabor a honey mustard', 'pringleshm.png' ),
		('4', '5', 'Cielo personal', 'botella', '1', '625', 'ml', 'Agua de manantial', 'cielo.png' ),
		('4', '5', 'Cielo grande', 'botella', '1', '2.5', 'l', 'Botella grande de agua de manantial', 'cielogrande.png' ),
		('7', '6', 'Tallarin', 'paquete', '1', '500', 'g', 'Fideos tallarin', 'molitalia.png' ),
		('7', '6', 'Pasta corta', 'paquete', '1', '250', 'g', 'Fideos codo', 'molitaliacodo.png' ),
		('8', '7', ' Arroz Extra', 'paquete', '1', '750', 'g', 'Paquete de arroz graneadito', 'costeño.png' ),
		('8', '7', ' Arroz Integral', 'paquete', '1', '750', 'g', 'Paquete de arroz integral', 'costeñointegral.png' ),
		('9', '8', 'Te Verde', 'caja', '50', '1', 'g', 'Caja de 50 filtrantes de te verde', 'wawateverde.png' ),
		('9', '8', 'Digestivo', 'caja', '12', '1.5', 'g', 'Caja de 12 filtrantes de digestivo', 'wawadigestivo.png' ),
		('6', '9', 'Zucaritas', 'caja', '1', '800', 'g', 'Cereal de hojuelas maíz', 'zucaritas.png' ),
		('6', '9', 'Froot Loops', 'caja', '1', '550', 'g', 'Cereal de maíz con colorantes naturales', 'frootloops.png' ),
		('10', '10', 'Gran Cereal Choco', 'paquete', '6', '32', 'g', 'Six pack de galletas gran cereal de chocolate', 'grancerealchoco.png' ),
		('10', '10', 'Cereal Bar Choco', 'caja', '8', '21', 'g', 'Caja con 8 barras de cereal sabor chocolate', 'cerealbarchoco.png' ),
		('11', '11', 'Lays', 'bolsa', '1', '80', 'g', 'Bolsa con aire y unas cuantas papas', 'lays.png' ),
		('11', '11', 'Doritos', 'bolsa', '1', '62', 'g', 'Bolsa con aire y unos doritos', 'doritos.png' ),
		('13', '12', 'PeziDuri', 'pote', '1', '1', 'l', 'Pote de helado de vainilla', 'peziduri.png' ),
		('13', '12', 'Frio Rico', 'cono', '1', '75', 'g', 'Cono con helado de vainilla y chispas de chocolate', 'friorico.png' );

insert into ProductoFranquicia(IdFranquicia, IdProducto, CodReferencia) values
		(1, 1, 1),(2, 1, 1),(3, 1, 1),(4, 1, 1),
        (1, 2, 2),(2, 2, 2),(3, 2, 2),(4, 2, 2),
        (1, 3, 3),(2, 3, 3),(3, 3, 3),(4, 3, 3),
        (1, 4, 4),(2, 4, 4),(3, 4, 4),(4, 4, 4),
        (1, 5, 5),(2, 5, 5),(3, 5, 5),(4, 5, 5),
        (1, 6, 6),(2, 6, 6),(3, 6, 6),(4, 6, 6),
        (1, 7, 7),(2, 7, 7),(3, 7, 7),(4, 7, 7),
        (1, 8, 8),(2, 8, 8),(3, 8, 8),(4, 8, 8),
        (1, 9, 9),(2, 9, 9),(3, 9, 9),(4, 9, 9),
        (1, 10, 10),(2, 10, 10),(3, 10, 10),(4, 10, 10),
        (1, 11, 11),(2, 11, 11),(3, 11, 11),(4, 11, 11),
        (1, 12, 12),(2, 12, 12),(3, 12, 12),(4, 12, 12),
        (1, 14, 14),(2, 14, 14),(3, 14, 14),(4, 14, 14),
        (1, 15, 15),(2, 15, 15),(3, 15, 15),(4, 15, 15),
        (1, 16, 16),(2, 16, 16),(3, 16, 16),(4, 16, 16),
        (1, 17, 17),(2, 17, 17),(3, 17, 17),(4, 17, 17),
        (1, 18, 18),(2, 18, 18),(3, 18, 18),(4, 18, 18),
        (1, 19, 19),(2, 19, 19),(3, 19, 19),(4, 19, 19),
        (1, 20, 20),(2, 20, 20),(3, 20, 20),(4, 20, 20),
        (1, 21, 21),(2, 21, 21),(3, 21, 21),(4, 21, 21),
        (1, 22, 22),(2, 22, 22),(3, 22, 22),(4, 22, 22),
        (1, 23, 23),(2, 23, 23),(3, 23, 23),(4, 23, 23),
        (1, 24, 24),(2, 24, 24),(3, 24, 24),(4, 24, 24);


insert into Cupon(Vigente, Codigo, Descuento,FechaExpiracion, FechaEmision, IdPedido) values
		(1, 'SCOTIA1', 10,'2019-12-30 00:00:00', '2019-01-01 00:00:00', null),
        (1, 'MAMA', 20,'2019-05-30 00:00:00', '2019-05-01 00:00:00', null),
        (1, 'PAPA', 20,'2019-06-30 00:00:00', '2019-06-01 00:00:00', null),
        (1, 'ANIVER', 30,'2019-12-30 00:00:00', '2019-01-01 00:00:00', null),
        (1, 'PROMOX10', 10,'2019-12-30 00:00:00', '2019-01-01 00:00:00', null),
        (1, 'PROMOX20', 20,'2019-12-30 00:00:00', '2019-01-01 00:00:00', null),
        (1, 'PREMIUM', 50,'2019-08-30 00:00:00', '2019-04-01 00:00:00', null),
        (1, 'BIENVENIDA', 15,'2019-01-30 00:00:00', '2019-01-01 00:00:00', null),
        (1, 'PERU', 15,'2019-06-23 00:00:00', '2019-06-21 00:00:00', null),
        (1, 'GAAAAA', 1000,'3000-12-30 00:00:00', '2000-01-01 00:00:00', null);