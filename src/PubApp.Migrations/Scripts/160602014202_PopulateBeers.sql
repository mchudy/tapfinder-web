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
				5,
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
				null),
				(N'Grand Imperial Porter Chili',
				N'Grand Imperial Porter Chili warzony jest tradycyjną metodą dolnej fermentacji wymagającą długiego leżakowania. Dzięki temu wykształca się niezwykle złożony bukiet, który w połączeniu z pikanterią chilli sprawia, że idealnie pasuje do letnich dań z grilla, szlachetnych mięs czy popularnych podczas letnich upałów deserów lodowych.',
				122,
				22,
				null),
				(N'Złote Lwy',
				N'Piwo Złote Lwy powstaje tradycyjną metodą, niezmienną od stuleci. W procesie warzenia wykorzystywany jest jedynie najwyższej jakości słód jęczmienny, selekcjonowany chmiel i woda z własnego ujęcia. Dzięki temu Złote Lwy charakteryzują się wspaniałym bukietem piwnych aromatów, złotą, mieniącą się barwą, niezwykle pełnym, wykształconym smakiem o wyraźnych nutach goryczkowo – słodowych oraz długo utrzymującą się pianą.',
				5,
				22,
				null),
				(N'Johannes',
				N'Johannes to jasne piwo o pełnym i dojrzałym bukiecie i wyraźnym, esencjonalnym smaku, który zawdzięcza długiemu leżakowaniu i wysokiemu poziomowi ekstraktu. Powstanie marki Johannes było wspólną inicjatywą Browaru Amber i Muzeum Historycznego Miasta Gdańska. Część przychodu ze sprzedaży piwa jest przeznaczana na zakup eksponatów do muzeum.',
				5,
				22,
				null),
				(N'Amber naturalny',
				N'Naturalnie niepasteryzowany. Naturalnie sięgasz po kiedy przyjdzie Ci ochota na wyraziste, dobre piwo. Naturalnie do grilla, imprez i spontanicznych spotkań w każdym miejscu i o każdej porze. Naturalnie świeży. Naturalnie z Pomorza!',
				5,
				22,
				null),
				(N'Amber chmielowy',
				N'Amber Chmielowy to jasne, goryczkowe, aromatyczne piwo, przyprawiane dwoma rodzajami krajowego chmielu: tradycyjną polską Marynką, której piwo zawdzięcza charakterystyczną goryczkę oraz aromatycznym Chmielem Lubelskim.',
				5,
				22,
				null),
				(N'Amber czarny bez',
				N'Amber Czarny Bez to połączenie klasycznego lagera z subtelnym aromatem kwiatów czarnego bzu, zbieranych raz do roku – na przełomie maja i czerwca. Naturalny wyjątkowy smak lata – zatrzymany w butelce.',
				5,
				22,
				null);
GO