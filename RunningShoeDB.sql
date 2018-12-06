use RunningShoe

begin transaction

create table brand
(
	brandID int identity(1, 1),
	brandName varchar(50) not null,
	avgCost int not null,

	constraint pk_brand_ID primary key(brandID),
);

commit

insert into brand values ('Asics', 90),('Brooks', 120),('Saucony', 110),('Nike', 140),('Adidas', 120),('Salomon', 130),('Altra', 130),('New Balance', 90);
