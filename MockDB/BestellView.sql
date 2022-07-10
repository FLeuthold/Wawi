CREATE VIEW [dbo].[BestellView]
	AS 

select b.id, ad.name as Adresse, ar.name as Artikel, p.menge
from [dbo].[Bestellung] as b
join Adresse as ad
on b.adresse_id = ad.id
join Position as p
on p.bestellung_id = b.id
join Artikel as ar
on p.artikel_id = ar.id;
