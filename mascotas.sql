create database ZOZO;

use ZOZO;


create table pets ("id" int identity(1,1) primary key,"name" varchar(20) not null,"specie" varchar(80) not null,breed varchar(40) ,birthdate date not null,description varchar(500) not null,image Nvarchar(max) not null,state bit not null);

Create table users(id_user int identity(1,1) primary key,firstname varchar(20) not null ,"lastname" varchar(20) not null ,email nvarchar(20) not null,phone int not null,adress nvarchar(50) not null,password nvarchar(50) not null,rol bit not null)

Create table adoption_request (id_adoption int identity(1,1) primary key,id_user int not null ,foreign key (id_user) references users(id_user) ,id_pet int not null,foreign key (id_pet) references pets(id),date_request date not null ,adoption_state varchar(20) not null check (adoption_state in('shipping','in progress','delivered')),reason varchar(250) ); 

select * from adoption_request;