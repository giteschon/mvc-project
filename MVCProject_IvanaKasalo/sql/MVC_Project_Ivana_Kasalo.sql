use AdventureWorksOBP

go
create proc GetCountries
as
select * from Drzava
go

create proc  GetCountry
@id int 
as
select * from Drzava where IDDrzava=@id
go



create proc GetCitiesForCountry
@idCountry int
as
select * from Grad where DrzavaID=@idCountry
go

create proc GetCity
@id int
as
select * from Grad where IDGrad=@id
go



create proc GetCustomersForCity
@idCity int
as
select * from Kupac where GradID=@idCity
go

create proc GetInInvoicesForCustomer
@idCustomer int
as
select r.*, kk.*, k.Ime +' ' + k.Prezime as Komercijalist from Racun as r
inner join Komercijalist as k
on k.IDKomercijalist=r.KomercijalistID
inner join KreditnaKartica as kk
on kk.IDKreditnaKartica=r.KreditnaKarticaID
where r.KupacID=@idCustomer
order by Komercijalist asc
go

drop proc GetInInvoicesForCustomer


--create proc GetCommercial
--@id int
--as 
--select * from Komercijalist where IDKomercijalist=@id
--go

--create proc GetCreditCard
--@id int
--as select * from KreditnaKartica where IDKreditnaKartica=@id
--go

create proc getItemsPerInvoice
@idInvoice int
as
select s.*, p.Naziv as Proizvod, pk.Naziv as Potkategorija, k.Naziv as Kategorija from Stavka  as s
inner join Proizvod as p
on p.IDProizvod=s.ProizvodID
inner join Potkategorija as pk
on p.PotkategorijaID=pk.IDPotkategorija
inner join Kategorija as k
on k.IDKategorija=pk.KategorijaID
where RacunID=@idInvoice
go



create proc EditCustomer
@id int,
@name nvarchar(50),
@surname nvarchar(50),
@email nvarchar(50),
@telephone nvarchar(50),
@idCity int
as
update Kupac set
Ime=@name,
Prezime=@surname,
Email=@email,
Telefon=@telephone,
GradID=@idCity
where IDKupac=@id
go

create proc AddDrzava
@naziv nvarchar(50)
as
insert into Drzava values (@naziv)
go

create proc EditDrzava
@naziv nvarchar(50),
@id int
as
update Drzava set
Naziv=@naziv
where IDDrzava=@id
go

create proc DeleteDrzava
@id int
as 
delete Drzava where IDDrzava=@id
go

create proc AddGrad
@naziv nvarchar(50),
@drzava int
as 
insert into Grad values (@naziv,@drzava)
go

create proc EditGrad
@naziv nvarchar(50),
@drzava int,
@id int
as
update Grad set
Naziv=@naziv,
DrzavaID=@drzava
where IDGrad=@id
go

create proc DeleteGrad
@id int
as
delete Grad where IDGrad=@id
go

create proc getDrzava
@naziv nvarchar(50)
as
select * from Drzava where Naziv=@naziv
go


create proc AddKupac
@name nvarchar(50),
@surname nvarchar(50),
@email nvarchar(50),
@telephone nvarchar(50),
@idCity int
as
insert into Kupac values(@name,@surname,@email,@telephone,@idCity)
go

create proc getKupac
@id int
as
select * from Kupac where IDKupac=@id
go

create proc DeleteKupac
@id int
as 
delete Kupac where IDKupac=@id
go

create proc getGrad
@naziv nvarchar(50)
as
select * from Grad where Naziv=@naziv
go

create proc getGradovi
as
select * from Grad
go

create proc getTipovi
as
select distinct Tip from KreditnaKartica
go

create proc getKomercijalists
as
select Ime + ' ' + Prezime as Komercijalist  from Komercijalist
go



select * from Kupac
select * from Komercijalist
Tip
select * from Stavka
select * from Drzava
select * from Grad
select * from Racun



