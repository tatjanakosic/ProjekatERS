create table Brojilo(
    ID int not null,
    ImeK varchar(20) not null,
    PrzK varchar(20) not null,
    Ulica varchar(40) not null,
    Broj int not null,
    Grad varchar(20),
    constraint pk_brojilo primary key(ID)
);

create table Potrosnja(
    IDB int not null,
    Potrosnja float,
    Mesec int not null,
    constraint pk_potrosnja primary key(IDB),
    constraint fk_potrosnja foreign key(IDB) references Brojilo(ID)
);

insert into Brojilo values(1, 'Pera', 'Peric', 'Strazilovksa', 10, 'Novi Sad');
insert into Potrosnja values(1, 40.0, 12);

select * from brojilo;
select * from potrosnja;

select *
from brojilo b, potrosnja p
where b.id = p.idb;