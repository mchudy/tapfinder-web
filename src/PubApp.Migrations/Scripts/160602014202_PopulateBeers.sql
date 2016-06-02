/* Migration Script */

GO
INSERT INTO [dbo].[BeerStyles]
           ([Name])
     VALUES
           (N'Porter bałtycki');
		   
GO
INSERT INTO [dbo].[Beers]
           ([Name]
           ,[Description]
           ,[BeerStyleId]
           ,[BreweryId]
           ,[ImagePath]) VALUES
				(N'Książęce Ciemne Łagodne',
				N'Ciemne Łagodne to unikalna kompozycja czterech odmian jęczmiennego słodu. Ma wyśmienity, łagodny smak i prawdziwy bukiet aromatów: od miodowo-biszkoptowego po czekoladowy i kawowy',
				27,
				10,
				null),
				(N'Książęce Czerwony Lager',
				N'Prawdziwy lager - niczym bursztyn, od którego wziął swą barwę - kryje w sobie niezwykły zaklęty smak karmelowego słodu skontrastowany z doskonałym chmielnym bukietem. Należycie schłodzony i podany do mięsnego posiłku odkryje przed Tobą nowe nieznane przestrzenie smaku.',
				22,
				10,
				null),
				(N'Książęce Złote Pszeniczne',
				N'Złote Pszeniczne to niefiltrowane złociste piwo warzone ze słodu pszenicznego, idealne do gaszenia pragnienia. Naturalną mętność trunku gwarantują piwowarskie drożdże, a ledwie wyczuwalna goryczka wzbogaca niezwykły smak.',
				31,
				10,
				null),
				(N'Pszeniczak',
				N'Nowa tradycja. Piwo pszeniczne pełne zapachów dojrzewającego zboża, chrupiącego chleba i świeżego ziarna. Naturalnie mętne, jak snujące się o poranku mgły nad łąkami. To jeden z najstarszych stylów piwa w Europie, który dzięki Pszeniczniakowi odzyskuje swój polski charakter.',
				31,
				22,
				null),
				(N'Piwo Żywe',
				N'Piwo Żywe to najbardziej znane piwo Browaru Amber i jedno z najbardziej utytułowanych piw w Polsce. Smakoszy zachwyca złoto-bursztynową barwą, naturalnie utrzymującą się czapą piany oraz głębokim słodowo-chmielowym aromatem.',
				15,
				22,
				null),
				(N'Koźlak',
				N'Koźlak posiada pełny esencjonalny karmelowo – chmielowy smak i unikalną rubinową barwę. Koźlak to historyczna nazwa mocnych piw dolnej fermentacji, bardzo popularnych w miastach Hanzeatyckich. Prawdziwa duma piwowarów browaru.',
				21,
				22,
				null),
				(N'Grand Imperial Porter',
				N'Grand Imperial Porter to przedstawiciel stylu Porter Bałtycki. Już od pierwszego łyku zachwyca smakiem palonego ziarna połączonym z nutami czekoladowymi, kawowymi, karmelowymi, wyczuwalnymi niuansami suszonych owoców. Wyróżnia się niezwykle gęstą, kremową pianą o doskonałej strukturze. Idealny do deserów, zwłaszcza do gorzkiej czekolady.',
				122,
				22,
				null);
GO