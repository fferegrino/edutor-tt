﻿/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/




DECLARE @DummyUsers BIT = 1,
		@DummyStudents BIT = 1,
		@DummyGroups BIT = 1,
		@DummyEnrollments BIT = 1,
		@DummyTeachings BIT = 1,
		@DummyQuestions BIT = 1,
		@DummyNotifications BIT = 1,
		@DummyEvents BIT = 1



IF(@DummyUsers = 1)
BEGIN
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Odysseus T. Wade','ETUQ990265LNNWPY72','pellentesque.a@facilisisloremtristique.ca','287-5801 Neque Road','0234303453','5021998354'),('S','Benedict H. Paul','CIBY457198YTWKRU65','diam.Pellentesque@Praesenteunulla.com','P.O. Box 377, 1776 Libero. Rd.','0818980771','2899729854'),('S','Brenden Patterson','GLBQ347762JXVITH87','vel.arcu.Curabitur@suscipitnonummy.org','P.O. Box 476, 3591 Eu Street','0288105994','7073928185'),('T','Michelle E. Albert','NTBG104976GFPBYM42','Praesent.luctus.Curabitur@Aliquamerat.net','P.O. Box 740, 9199 Nunc St.','0684001896','1347304070'),('T','Ginger Valdez','PQSN921058EHISWM18','torquent.per@interdum.ca','511-6583 Justo Rd.','0043498056','2581432966'),('S','Whitney G. Ball','DORD624610QZZEVN99','ante.blandit.viverra@arcuSedeu.net','770-6722 Est St.','0208353883','1476367123'),('S','Tad Owens','EJLT584234JIWUNZ66','mi.Duis.risus@rutrumFusce.org','481-5545 Maecenas Road','0689739785','8381569380'),('S','Lesley Sweet','EVDI600621MLNQSE58','dolor@dui.ca','3546 Integer Av.','0032894654','1437797157'),('S','Benjamin H. Dudley','FRQI281577CHOHHF74','velit.dui.semper@etmagnisdis.edu','881-766 Nullam Street','0222115319','4055461445'),('S','Ahmed K. Miles','JSVS640375CPZCRZ32','dapibus.gravida.Aliquam@et.edu','Ap #894-7750 Lectus Rd.','0178327795','4923519365');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Cassidy O. Gutierrez','JNKE968528OEMZYM38','Etiam@lacusMauris.co.uk','341-7979 Volutpat. Av.','0171105380','1856356252'),('T','Preston V. Clay','ZVPP860900AWHCVZ51','pede.malesuada@ultricesposuerecubilia.com','Ap #328-8169 Libero Ave','0269841293','6243276079'),('S','Fleur Z. Bean','NALN034292LJENRD50','netus@Crassed.co.uk','9837 Ante. Avenue','0420085315','1722910885'),('S','Elizabeth Alvarado','DNEY145989MBPSYA98','mollis.lectus.pede@turpisvitaepurus.edu','835-458 Cum Avenue','0732191076','8457882062'),('S','May Parsons','KNGP189491BHTZLA30','nonummy.ultricies@netus.org','P.O. Box 345, 8207 Vitae Rd.','0572548136','2835249770'),('T','Lane Smith','ZCYK166986ZRTLSJ89','hendrerit.Donec@sagittissemperNam.net','193-5649 Sed St.','0982126262','1559287690'),('S','Tucker Dale','QBZC260103AKKGLQ33','Lorem.ipsum.dolor@erosnon.co.uk','4970 Cum Rd.','0441101169','1428545269'),('S','Ulla Stout','ABKZ607668NVIQTL64','penatibus.et@Fusce.org','614-9864 Metus St.','0259591233','2269749034'),('S','Yoshi Anthony','VWHS527715JBWSVH27','accumsan.neque.et@Mauris.net','Ap #922-9225 Feugiat. Rd.','0678240967','7408377141'),('T','Addison B. Olsen','IKGO884820XCBXMN29','varius.Nam.porttitor@inmolestietortor.edu','506-6488 Pretium Street','0647878155','3324086594');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Caryn F. Perkins','TWZR029759LNJRHD00','ullamcorper.nisl.arcu@consequat.co.uk','799-9669 Conubia Rd.','0451724087','5004569743'),('S','Fletcher A. Blackwell','BIGH982877PMLDOD14','purus.mauris@sed.ca','P.O. Box 410, 5525 Consectetuer Rd.','0275644003','6335656849'),('S','Benedict J. Barry','KIPA071118JDCXEI12','sed@egetmassa.ca','934-7196 Mollis. Rd.','0977176874','1293103320'),('T','Garrison X. Nash','BRNE382732WUGDRN32','Sed@semegetmassa.net','P.O. Box 365, 5407 Ultrices Ave','0462162135','7225674135'),('S','Darrel Woodard','MXRG109651SGRCVR02','nulla@quamCurabiturvel.ca','P.O. Box 521, 7218 Nulla Rd.','0996742892','7316942211'),('S','Emma Boyd','VMOU741869HDWHVP80','sed.est.Nunc@Vivamusnibh.net','P.O. Box 934, 6362 Eleifend. Street','0505155659','1605333430'),('T','Natalie Wynn','MZHO124599UEMYHP20','Sed.malesuada.augue@aptenttacitisociosqu.ca','P.O. Box 968, 9551 Mollis. St.','0607993773','5819290252'),('S','Graham I. Hunt','BDXG908755XQOWFL65','Vivamus.euismod.urna@sempereratin.com','4132 Eu Av.','0737624034','9666428808'),('S','Idona Pugh','JJVE136274OLPMEL24','cursus@enim.com','Ap #826-7153 Eros Ave','0221059199','7402613489'),('S','Brent Bowen','TQRF522341RGBPWE90','aliquet@dictumultricies.net','3196 Vitae Ave','0689845915','5791242136');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('T','Adena Grant','CEVO852867TJKFYG44','justo.eu@dictumProineget.net','795-5910 Suscipit, Ave','0364520293','9574138039'),('S','Megan Rosales','RNEB387911JEAEEM84','pede.ac@lectusrutrumurna.ca','P.O. Box 666, 922 Phasellus Rd.','0248050957','1441530086'),('S','Ira Fischer','FQDF611407XWAOJV15','eu.tellus@iaculis.org','2186 Donec Ave','0261046411','3481875167'),('T','Ava P. Suarez','GMYA765450TLTNHE32','aliquet.magna@lectus.net','P.O. Box 785, 9291 Sed St.','0964273895','6838262589'),('S','Grant Beck','YOMM995804RHSLGO00','mi@arcuVestibulumante.co.uk','Ap #251-9703 Nibh Av.','0501620883','5048019285'),('S','Brianna Bradford','WNHP638525UXUVDA20','vitae@convalliserateget.com','P.O. Box 412, 4351 Nullam Ave','0784487771','9844551902'),('S','Noel H. Knight','QXLG177972LXKGXX93','vel@facilisisSuspendissecommodo.org','Ap #792-7152 Class Av.','0664553397','5001745660'),('S','Shelley Page','WJLF457516JPBIRK04','massa.non@telluslorem.ca','298-1404 Praesent Av.','0813138516','3859316318'),('S','Uta Joyce','WYNF875242RIGKPT59','ut.erat@a.net','P.O. Box 389, 6781 Morbi Av.','0323891120','7885884179'),('S','Cameran Z. Sandoval','LQAZ618289TPRPBN24','lacus.Etiam@vitae.ca','P.O. Box 547, 7447 Volutpat St.','0615914530','3748054358');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('T','Rashad Perry','EZHN565046WCNVUB51','augue.eu.tellus@turpis.co.uk','225-173 Erat, St.','0434570096','5825808999'),('T','Kim K. Oneill','AVHE847374YKLWAN50','vel@penatibus.net','P.O. Box 349, 5540 Ornare Road','0767148888','7824543778'),('S','Graham Castillo','VWEA666263OHTWMA59','lacus.Etiam@Sedauctor.edu','Ap #247-1445 Ante St.','0072878856','1418762188'),('T','Nora N. Holland','ZPIE889914JKDCBP96','Fusce@gravidamaurisut.ca','Ap #165-8751 Fusce Street','0478767437','9774043322'),('S','Sydnee I. Glenn','DPUT562123IZFUWF82','Quisque.ornare.tortor@aliquetProinvelit.net','833-8435 Dictum. Rd.','0049804783','5432793047'),('T','Trevor B. Levy','DHQV923207WCHDZJ33','ac.facilisis@miDuisrisus.edu','1709 Nunc Rd.','0811392340','2625614830'),('T','Hayden Faulkner','PRJG268171PADLWN31','lobortis@NulladignissimMaecenas.org','Ap #996-8517 Eu Rd.','0565432967','4741145709'),('S','Sara R. Maynard','WHQM915366DOZAVY26','ipsum@nibhdolor.net','699 Ligula Street','0403882813','1745349273'),('T','Merrill Clarke','JPWP565270YTZNNX46','sem@odiosemper.net','3058 Tincidunt Ave','0319576052','8259066332'),('S','Francesca Talley','RDCY650001WIPEDM66','sed.libero@semper.co.uk','Ap #350-1091 Quisque Av.','0750671318','9851169572');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Whilemina E. Waters','ECHH244928PZSWKV39','mollis.non@Vestibulumante.org','P.O. Box 497, 8187 Elit Rd.','0584505436','3935917979'),('T','Mannix E. Burgess','MPKU117517SSHUXN51','diam.nunc@Quisquetincidunt.com','Ap #826-8094 Ut Rd.','0026534883','4031515060'),('T','George Blair','UVBB269453TOPUVN85','neque.sed.dictum@iaculis.ca','979 Nibh Road','0940370219','8237629503'),('T','Bradley D. Gates','GEBI818109XYJFLN96','orci@Sedeu.net','8721 Vitae, St.','0209262544','2516337930'),('T','Athena Lee','IEXY684999VZDOPB01','fermentum.convallis@Vestibulumanteipsum.ca','7856 Semper Av.','0271195885','8452247861'),('T','Justine Z. Willis','INTE952169JJVGCD38','libero.nec.ligula@ascelerisquesed.com','4987 Accumsan St.','0099887719','7855296989'),('T','Yael Rios','GYOJ035878HXFIPJ97','ligula@sed.com','Ap #853-974 Pretium Rd.','0142565192','2288076902'),('S','Jack Pruitt','MNLC734351MZADVO74','cursus@eteuismod.co.uk','841-9838 Massa Rd.','0052584787','4452107643'),('S','Timothy T. Horn','MQOH811809QICFJX12','tempor.arcu.Vestibulum@metusIn.ca','Ap #966-7558 Blandit Av.','0542882152','7004187661'),('T','Faith L. Baldwin','VYER204569MIGZTB82','ac.risus@Aliquamultrices.ca','706 Mauris Street','0894114052','5905765325');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('T','Nichole Christensen','VFUV723876FBTRHK90','sagittis.Duis@semperpretium.edu','582-7184 Class Av.','0655483964','3244820232'),('T','Stuart Hoffman','BFSV108491TILHPK56','at@feugiatLoremipsum.org','Ap #637-4986 Aliquam Rd.','0014849473','2534992271'),('S','Amity Collier','RULF435403YOHOZF09','placerat.Cras@euaugue.org','343-8728 Massa. Avenue','0505748796','5131835350'),('S','Georgia Robinson','GPOH688031GWKBOH56','vitae.risus.Duis@vulputateeu.net','7394 Dictum Road','0286572208','7403115000'),('S','Vernon P. Arnold','MEOZ678597VCQSVE52','feugiat.tellus@acurnaUt.org','Ap #507-7719 Ornare, Street','0847833363','5121157535'),('S','Melanie C. Mcmahon','EEQK651848EJOLQH20','cursus.a@Cras.net','289-7586 Pede Rd.','0889149722','8014836688'),('S','Conan M. Hartman','JNNQ826169BUNXKL61','luctus.ipsum.leo@idrisus.co.uk','Ap #443-9751 Nec Ave','0634752805','6465357920'),('S','Kelly I. Cantu','QESU380654ENPNFC49','Proin.ultrices.Duis@velsapienimperdiet.net','Ap #867-4218 Arcu Street','0275535625','6453705888'),('T','Irene U. Lynn','NUXL595269GNZXJY40','eu.erat@magnaseddui.co.uk','P.O. Box 303, 5436 Sit Rd.','0747245651','5556718757'),('T','Tashya G. Morgan','RRTZ500667PBIERU62','dictum@posuere.ca','3314 Rutrum St.','0561430566','6968319657');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('T','Yardley N. Benjamin','ZBSZ645096FTXAOA39','magnis.dis@Curabitur.net','P.O. Box 441, 1358 Venenatis St.','0281912591','5204980795'),('S','Zelenia E. Peterson','CAGY912641AZLEFW97','malesuada.fringilla.est@primis.ca','809 Magnis Ave','0135541252','3684633012'),('S','Darrel Morales','JTPZ591601KTIOCR66','eu@nonlorem.com','898-7031 Sed Street','0976869041','5209383880'),('T','Laith D. Harvey','QYOY989122GYSVXH28','libero.Integer.in@ornaretortorat.co.uk','816-7318 Aliquet Street','0552572353','6655318923'),('S','Yael Cochran','QUES303973KNFCRX18','sapien.Nunc@risus.org','8517 Lacus. Av.','0193702724','3072101763'),('S','Lane Ayers','TPIG882507TQQPLA45','semper@interdumliberodui.edu','P.O. Box 511, 8806 In Ave','0085065265','8859033169'),('T','Heidi Cook','FJNU406177ZDHREA91','Aliquam.tincidunt@eumetus.co.uk','8216 Eu Street','0024840429','7772772450'),('T','Willow B. Phelps','SIIX735585HUFURS51','neque.venenatis.lacus@estNunc.net','4291 Et Ave','0247623599','8457451708'),('T','Britanni W. Hoover','DQHP133834UAATBB86','egestas.blandit.Nam@venenatis.net','Ap #955-2656 Sit St.','0867167583','5239922811'),('S','Barclay Newton','PHTJ535568KKRFRB63','malesuada.vel@elitpharetraut.net','Ap #353-1928 Consequat Ave','0461367378','8519865494');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Quinn D. Moody','OHGG168545UFKZWK25','a.feugiat.tellus@etarcuimperdiet.com','Ap #725-2319 Nulla Street','0509466054','7033908570'),('T','Logan L. Lang','CVLO611104EFVHAX43','eget.massa.Suspendisse@ProinmiAliquam.edu','164-8422 At, Road','0014770460','3801907387'),('S','Rama D. Gutierrez','YKNZ254199YPMTCF46','accumsan.laoreet.ipsum@ametmetusAliquam.com','2712 Sit Rd.','0218652882','2042171920'),('T','Chester Ratliff','QUQQ181786INSBAN32','congue.In.scelerisque@aodio.edu','2081 Elit. St.','0135296723','4865514001'),('T','Aurelia N. Powers','VSZZ681504BGBGZG89','urna.Nullam.lobortis@vel.com','P.O. Box 518, 1976 Tellus St.','0629623846','2994381940'),('T','Yasir C. Blevins','AURE066280KDUVWU40','penatibus@natoquepenatibuset.co.uk','Ap #474-8185 Lobortis Street','0164665091','6105015383'),('T','Hedwig Daniel','JCMX380786OIKKWZ35','Pellentesque.ut@ornareelitelit.edu','375-1709 Quam Ave','0535990037','4667844970'),('S','Margaret Z. Hendricks','XBCQ421536JEINUA19','vitae.purus@sodalespurus.net','9813 Sem, Ave','0191454663','4408600320'),('S','Kaden Q. Hansen','SMHQ791666EPFGVY50','non.enim@Nullamutnisi.co.uk','299-9970 Congue St.','0304863964','9287887030'),('T','Yoshi Z. Hammond','KHBP381587VYMCZR07','enim.mi@Phasellusin.co.uk','7044 Lorem Rd.','0409549449','4886878763');
	INSERT INTO Users([Type],[Name],[Curp],[Email],[Address],[Mobile],[Phone]) VALUES('S','Iola R. Figueroa','CGCC962368QOZVWG01','Nunc.quis.arcu@tincidunt.edu','292-5547 Odio. Rd.','0113203515','2308161206'),('T','Cairo Chaney','ADCV818338LIPFMC29','mi.tempor@mifelis.com','Ap #388-1548 Neque Ave','0138346865','8816363220'),('S','Latifah F. Spencer','NFLZ986120WLUAWZ85','Cras.eget@pharetranibhAliquam.org','6889 Dolor. Rd.','0354192393','4756595479'),('S','Nadine Black','SAMR725355QKPIXH90','consequat.purus.Maecenas@auctor.edu','Ap #164-4530 Mauris Road','0833779116','9508764142'),('S','Ryan Boone','RQRB695904UPOISW31','egestas@atarcuVestibulum.co.uk','Ap #657-9030 Tempor Avenue','0437357179','9381095670'),('S','Tobias Q. Moon','DIHO215206MXLITH46','eu@est.net','3184 Auctor St.','0497612116','4674424775'),('S','Colorado A. Tran','ZGHA997725IOUCWY25','consectetuer.mauris@auctor.com','P.O. Box 819, 4076 Egestas. Ave','0394710239','3254647549'),('S','Cameron D. Fuentes','PFGI274811RPCQCM60','sagittis.Duis@Duisgravida.co.uk','420-7484 Aliquet Road','0402092413','2553245175'),('T','Tyler Y. Edwards','NCOS398035PIFGEI19','a@eleifendnuncrisus.ca','P.O. Box 745, 9179 Lectus. Rd.','0977895923','7464954445'),('T','Latifah Richards','TKGF096345RVWHYQ42','ultricies.dignissim@sociisnatoque.ca','Ap #502-3942 Nisl. Av.','0833557639','1899376391');

	UPDATE Users
	SET Position =	CASE ABS(CHECKSUM(NewId())) % 3
					WHEN 0 THEN 'A'
					ELSE 'P' END
	WHERE [Type] = 'S'
			AND UserId > 1

	update Users set [Password] =  CONVERT(varchar(max),HASHBYTES('SHA2_256',Curp),2)
	from Users
	where UserId > 1


END

IF(@DummyStudents = 1)
BEGIN


	CREATE TABLE #DUMMYDATA(
		I INT NOT NULL IDENTITY(0,1),
		UserId INT NOT NULL
	)

	INSERT INTO #DUMMYDATA (UserId)
	select UserId
	from Users
	where [Type] = 'T'


	CREATE TABLE #MID_STUDENTS(
		[StudentId] INT NOT NULL IDENTITY(0,1),
		[TutorRelationship] CHAR(3) NOT NULL, 
		[Address] VARCHAR(512) NOT NULL, 
		[Phone] VARCHAR(10) NULL,
		[Name] VARCHAR(60) NOT NULL,
		[Curp] CHAR(18) NOT NULL,
		[Token] CHAR(10) NOT NULL 
	)


	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('oth','Ap #137-7880 Felis. Rd.','8596367189','William Z. Marquez','OUBE136714NGSTJ7QM','21DKUHR8SK'),('unc','P.O. Box 461, 5032 Posuere Rd.','5867594449','Cullen E. Perkins','RUUP337115NSNSL1OM','71JVMKY6VY'),('oth','1515 Magna. Street','8822414269','Clark Newman','SDZZ628743ZZLFK4CO','56UQXGV2HU'),('mom','2011 Ligula. Avenue','7791859391','Nero A. Phelps','IONK373817PGJKD2GZ','92HWBWO4PL'),('unc','Ap #263-4103 Eu Rd.','2325362622','Darryl V. Sandoval','LYZQ798387DGSJF9HY','42ZGKUI6GB'),('dad','Ap #105-642 Consequat Av.','5353267251','Ivory Bauer','VXDE776494CWLOA6HV','49VBCQB7ZH'),('oth','Ap #390-637 Inceptos Rd.','9753435507','Rhoda Q. Olson','URJZ583369FXWTR5VW','19LDNBS2WE'),('aun','4945 Nec, Av.','8065247707','Shannon H. Haley','IGCX915246NKSPF6TO','89SULPR1BJ'),('aun','P.O. Box 678, 3923 Mauris Street','2244362502','Katelyn Head','NRYC643985CIGAZ2KU','16MDELM3EG'),('unc','868-5607 Adipiscing Ave','4781468692','Adena L. Evans','BMYD518431EMJFY1LF','89LQRRL3TK');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('unc','952-9014 Scelerisque, Road','8467966935','Jane Guzman','MVBR433575YIVUC6IM','56UTVXX8WF'),('mom','Ap #208-5448 Non St.','1517499244','Mara M. Weiss','ABWC575176HJJPJ5MF','57ACTEX6YY'),('unc','P.O. Box 658, 4099 Malesuada Street','6275428975','Quynn R. Drake','YIIV488969JLUKX4TJ','74ELYEN6QI'),('unc','2923 Dolor. Road','3938294295','Wing Puckett','MITU771592YENWN2IL','28AOWZK9OF'),('unc','Ap #222-6304 Sit St.','8237254487','Anika Mccarthy','VDQV872368GRVOJ6OO','98VRVXI8LH'),('oth','3492 Pharetra. Rd.','7498430537','Adara M. Frank','YSOY533459YCBOL8ZH','88OFMUT7CS'),('oth','1214 Nunc Street','5799346146','Mechelle Garrett','TUEO766668DNMFW5AO','38CQIVE5VY'),('aun','Ap #152-4127 Turpis Rd.','7613573614','Naida E. Bradford','LMVM774829ICPAU1TN','51JXXCK4ZN'),('aun','2807 Eget St.','9222715859','Germane Moss','VUMA882747FUUNY2RD','62EXQSX3HW'),('aun','949-6387 Fusce Rd.','4563328393','Brian Woodard','FDXV978234XFDEB5RF','93XTPWK8MT');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('aun','531-6850 A Rd.','8552130325','Lev Mcfadden','KWGS555235GAYLW4VM','74HQSCL7FH'),('aun','Ap #865-2858 Quisque Rd.','3768696812','Shelby Sanchez','QEPA416922MBVDI8UC','96UTTDF1LT'),('mom','402-3983 Vel St.','4539665921','MacKenzie R. Graves','JXAY171279TIQZM5PE','25UKOHF1XK'),('aun','Ap #390-3141 Ut St.','4998176934','Anastasia Q. Shepard','JRZC599868MOJKW4DG','76HVOBR3VX'),('unc','P.O. Box 831, 5741 Nisi. Av.','2234312227','Rae W. Myers','KPXH631239SEAVB9DO','42ILYIZ9NN'),('aun','Ap #586-5124 Aenean Street','4052121376','Isaac Curtis','VIBB652954LFGEQ2ZH','76WDEAG7NZ'),('unc','6578 Urna Rd.','9549642429','Renee T. Hatfield','MJFL252598WYFUH7LE','35VSBMJ2VZ'),('unc','P.O. Box 531, 7404 Nunc Ave','1889120688','Germane W. Durham','RQFY997298EXWXJ1FS','71CLBFY2LR'),('mom','P.O. Box 580, 1159 Vestibulum Ave','4079380369','Alea Owen','OKXO174521NGTGQ8CY','14YHRLO9PV'),('oth','Ap #567-2120 Vestibulum St.','4196166704','Mollie J. Chan','VSOE447271YKWIX5JZ','69MIQOZ3VU');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('unc','Ap #842-3304 Euismod Av.','5632637245','Xanthus S. Brewer','XMQJ727151YDFVU3XO','61ZJQJQ5JY'),('mom','Ap #718-7893 Hendrerit Av.','8351979461','Ignatius S. Compton','WBNS695227HKKBF5FP','83AYJKW2AK'),('dad','Ap #750-911 Parturient St.','7312716613','Francis H. Norris','DJYX315736MEZDB6JG','57THFEQ5CU'),('aun','Ap #401-4039 Ultrices Ave','2679281546','Dolan Britt','WERN326128XXCBL3LS','46OEIAB3SD'),('dad','146-9934 Eu, St.','1482371811','Tamekah K. Stewart','PHRR178275CZWBN9BA','15GXFBR3PB'),('unc','364-7387 Cras Avenue','5284617329','Driscoll Y. Jefferson','KGPK941746ETFWF5XK','58OQIZM9NK'),('unc','4363 Congue Av.','2871862857','Lenore W. Ryan','QPTY451317RWYLS5UK','68METZJ2LA'),('aun','P.O. Box 880, 6525 Dictum Rd.','9430312649','Noble Z. Mclaughlin','UOUW358333QCRZM3YT','59PGGOM2MZ'),('mom','P.O. Box 551, 1029 Quisque Rd.','8562556672','Karen Dorsey','XQDA163574WZSFV4JZ','29CKTQZ5NK'),('mom','Ap #163-5882 Blandit Rd.','8423682123','Ariel Pearson','FMQG442463CVTHA9BO','34VNPHI1SK');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('oth','Ap #545-5439 Ipsum Road','1364752508','Dale Y. Jennings','ROCH114343XOIQI4NC','78HNIQI6ZX'),('unc','P.O. Box 104, 4700 Lectus Rd.','1213328539','Quynn Mclaughlin','LCYU646675WEAUT6XK','96PEQLT7XF'),('unc','138-6800 Tincidunt Ave','2588276639','Daryl R. Strong','WZHJ979941RSVQR1EV','97ZAABF7KV'),('unc','Ap #837-2429 Gravida St.','8711697495','Chanda R. Case','PNXM234465UYTPF1BH','92ARWNH6LB'),('aun','Ap #384-2678 Egestas St.','2058289126','Isabelle U. Kennedy','MIBY337121HXQGD9VF','13DJLFW8OW'),('oth','Ap #152-5846 Risus. Rd.','4168889123','Emmanuel S. Noble','DFID389649VGFWY7AC','59LCIJO6DC'),('aun','542-3553 Diam Rd.','7097950264','Avram Emerson','WYCY153412NHQSM4FV','38PDOHL1BJ'),('mom','294 Morbi Rd.','2929120159','Farrah Cochran','FSSW855688FWQBU9OT','69FNWLA1RK'),('aun','816-447 Nec Rd.','8344175308','Donovan Nunez','GDZL587445HTOLJ5WE','76GXUVF2YY'),('mom','P.O. Box 868, 8106 Arcu. St.','1373320709','Wyatt A. Mathis','BFXF355417YNRKM7BO','15ZIBGR8CB');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('oth','3911 Urna Rd.','6914664579','Jeremy K. Fletcher','WIAA332872VQJPQ8DN','36NGOOX1LA'),('unc','811-431 Sit Road','7026587822','Eleanor E. Franklin','XKJJ871756TEEWC8MU','79WNEMD8KC'),('unc','Ap #106-1400 Quisque Rd.','8740633429','Paul Mcintosh','UMLJ232533ZCCTB5BJ','92NXAFG3XT'),('unc','6292 Vulputate, Road','7086780248','Rajah Beck','GXIT945919SQTTY4IX','88CPHDE9SF'),('oth','820-8414 Vulputate St.','5388636399','Ori G. Salas','VEDB552896TBZZL1PX','48TDNPC5FP'),('dad','479-3906 Mattis St.','5645739324','Jared I. Mcintyre','NDXF262752SNNGJ5IA','49BGAMK9UY'),('unc','739-3718 Malesuada. Rd.','5122892719','Courtney R. Goodman','CCXZ483138BHHYW1TZ','73OUMJS2EW'),('mom','788-5567 Molestie. Av.','3613175297','Charde O. Peck','DTNT516941KWFOT6SQ','71SXYXQ9TE'),('aun','Ap #400-8850 Mollis St.','1016559266','Austin Combs','JOHL855287SWHZL4XH','99QBDSR7XD'),('unc','Ap #344-4569 Nec Ave','5858335768','Venus J. Welch','AARJ965915PXWFS9FN','75KVKBX3NJ');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('unc','Ap #810-3848 Sed Rd.','8872716417','Ferdinand Wallace','OYZI486734CMOTU9SE','56UIHEG9VK'),('aun','Ap #172-5338 Eget Rd.','4947954792','Reece Hale','RRID139395TCRGI6US','61OCFHO3YJ'),('mom','512-5713 Ut, Rd.','7457457578','Alfreda V. Melton','SMYS276714VMJSJ4TY','48NVQVN9SS'),('aun','774-9247 Molestie Street','5324475963','Hollee H. Willis','PLPU887698KRQFG4JM','39WZDQX1BX'),('dad','304-6040 Vulputate Rd.','6760928275','Ulric R. Wright','NVMN836859WSIXU1UF','95OATPR8GK'),('oth','P.O. Box 387, 9457 Magna Rd.','1295589923','Chester Howard','XJWK746486YVWNK9LB','71YKMHI4UB'),('aun','5892 Elementum St.','2916112149','Maia I. Marks','JGSD839333TYVBQ8YI','11LPKRL8HJ'),('aun','P.O. Box 635, 1150 Id Avenue','5259885849','Theodore D. Pate','XKPP916494NXXEN1ZK','43NFSBU7UG'),('oth','638-6434 Proin Rd.','3935496575','Lane F. Gilbert','NUXW588234PTFMD7XI','36TTVKC6HI'),('aun','P.O. Box 284, 6711 Faucibus. Ave','4534191271','Maya E. Horne','UAVL321542KARYB5EC','84POQFZ6BG');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('unc','P.O. Box 171, 5807 Adipiscing Rd.','3954483439','Nyssa Preston','UUKT915446LOHQB8GV','38NHEXO7WY'),('unc','9548 Phasellus Avenue','1222286663','Andrew J. Warren','YVQY861166CWUBC3ZF','62BDYVB9KV'),('unc','Ap #748-9449 Dignissim Av.','1249874899','Brielle Good','RHTD925667IUTZC1UZ','96UPYPR2MA'),('unc','Ap #707-999 Non Avenue','8112879623','Sharon Jackson','MMDM296329ECDOX8BY','43CBXVK6HP'),('aun','P.O. Box 761, 6371 Sed, St.','3347421228','Hope Mayo','HGVX569745XWHID1AJ','42PQAHP6MZ'),('oth','P.O. Box 537, 8325 Justo Av.','2554877789','Brynn Morrow','AOSJ957922THRLH8FD','74FGQEY3YO'),('unc','947-4097 Metus St.','4535616166','Tatum V. Baker','WCJP795967TKWWE9KU','42HLDHE9SS'),('aun','274-9612 Donec Road','4492966367','Phelan H. Dillard','EFUN614645IWRYX8GJ','42SBHDS4GC'),('oth','P.O. Box 944, 2438 Phasellus Rd.','2849176274','Christopher Z. Bond','JUCK596784SQYTU8UH','69XNJYD6EI'),('mom','551-6258 Tempus Road','2331923709','Xanthus Garner','VZOD945284IHVBB7FQ','57MIIHR4VE');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('oth','644-8960 Venenatis Road','4966391389','Merrill Z. Hodge','NHIR253931ILICV2YC','69GTTQE7PN'),('mom','2978 Proin Rd.','3658679366','Jael W. Wells','PXWS593465CAMES3VG','21FPRWE7RG'),('mom','P.O. Box 254, 5828 Erat, Av.','6955148309','Michael Tillman','CSQI817879MMGES6RB','36OAMFB1KQ'),('dad','Ap #978-7617 Nulla. St.','1470798382','Carter Barker','KUUZ796951CWWXA6FK','68MFEWZ9FI'),('oth','P.O. Box 450, 1484 Penatibus Rd.','5020746953','Brian Buck','JREY561525FEWZA8YI','26NGGNK1JJ'),('aun','802-809 Mauris Rd.','8555761845','Rylee G. Sellers','ACFG698916TMVVZ9WI','26KMBJQ6KL'),('mom','116-4138 Sit Street','3952914747','Lani Bush','ZYCL651422QBDRV6MU','84AANJF8SK'),('dad','Ap #917-4725 Auctor Road','9429663666','Cleo Carrillo','TGYG688537MGSKB9GB','14XYDZT3WP'),('aun','2101 Tincidunt St.','9296410539','Jordan L. Mason','USTP541639WSGFR7ZI','59UMRPN1SP'),('aun','742-8909 Sem Ave','6764443653','Kiayada Kaufman','VWMU834148TJMSC7BI','23VZRUG2IR');
	INSERT INTO #MID_STUDENTS([TutorRelationship],[Address],[Phone],[Name],[Curp],[Token]) VALUES('mom','Ap #927-664 Consectetuer, Av.','2637694322','Willa Pace','LIRK671183HFNLW4QJ','73SAZCV3VL'),('oth','9761 Accumsan Avenue','9794735112','Kimberley F. Richard','COTB793367XHZRE5BR','76NJJDT5RP'),('mom','6417 Risus. Rd.','5745590931','Astra G. Wilson','OBZH632117WOJGQ9UV','11ZYDOY8SG'),('unc','6386 Arcu Avenue','8969929586','Althea Hurst','BYLW415827PJAHX7BI','86OQNRT7BW'),('oth','P.O. Box 921, 8859 Penatibus Ave','1612668956','Deacon W. Roach','ZMYF532324KNOZK3DP','23VVVUI1LC'),('unc','527-306 Penatibus Ave','4365341495','Risa Lane','HIDO164573MLPMD3XD','89LOYXL1OT'),('mom','Ap #266-4137 Nec, St.','6693541444','Herman Y. Christian','FEEV869894GZDOL8VU','88DIMSN2WA'),('aun','P.O. Box 137, 503 Ut Avenue','5625269929','Orson Petersen','XWLL591492ZYRPL9NC','49KESNI5OS'),('dad','P.O. Box 371, 9439 Elit Avenue','5136123279','Philip B. Whitaker','LKDD332142JBCRE1HL','38FKIWN7SZ'),('unc','Ap #893-5038 Nec Avenue','6823169719','Demetria Church','JMSL721512YAFTK3XE','34QNODF4JW');

	DECLARE @TutorsCount INT, @StudentsCount INT, @i INT = 0

	SELECT @TutorsCount = COUNT(I)
	FROM #DUMMYDATA

	SELECT @StudentsCount = COUNT(Curp)
	FROM #MID_STUDENTS

	SELECT @TutorsCount, @StudentsCount

	WHILE(@i < @StudentsCount)
	BEGIN
		INSERT INTO Students (TutorId,[TutorRelationship],[Address],[Phone],[Name],[Curp],[Token], [IsActive])
		SELECT (SELECT UserId FROM #DUMMYDATA WHERE I = (@i % @TutorsCount)) AS TutorId
			,[TutorRelationship],[Address],[Phone],[Name],[Curp],[Token], 1
		FROM #MID_STUDENTS WHERE StudentId = @i
		SET @i = @i + 1
	END

	DROP TABLE #DUMMYDATA
	DROP TABLE #MID_STUDENTS

	update Students set Token = 'A' + SUBSTRING(Token, 1,9) 

	UPDATE Students SET IsActive = 0

END

IF(@DummyGroups = 1)
BEGIN

	INSERT INTO Groups([Name],[Subject],[FromDate]) VALUES('lorem ut','in, hendrerit consectetuer,','11/27/2014'),('Nam porttitor','congue a, aliquet','04/03/2015'),('enim. Nunc','Duis cursus, diam','06/17/2015'),('orci. Phasellus','a mi fringilla','08/07/2014'),('Duis ac','non arcu. Vivamus','05/31/2014'),('Integer mollis.','Nunc pulvinar arcu','10/11/2015'),('Nam ligula','dapibus gravida. Aliquam','08/31/2015'),('Nam nulla','ut dolor dapibus','02/01/2015'),('nec, imperdiet','semper cursus. Integer','08/13/2015'),('a, aliquet','Vivamus euismod urna.','02/11/2015');
	INSERT INTO Groups([Name],[Subject],[FromDate]) VALUES('odio. Aliquam','scelerisque neque sed','02/01/2016'),('orci luctus','Morbi neque tellus,','06/06/2015'),('urna justo','laoreet ipsum. Curabitur','01/17/2016'),('iaculis, lacus','Nunc ullamcorper, velit','03/30/2015'),('Sed auctor','at, egestas a,','11/06/2014'),('vulputate velit','Quisque nonummy ipsum','10/03/2015'),('nunc risus','tincidunt tempus risus.','02/18/2015'),('penatibus et','nisl. Nulla eu','07/30/2015'),('pede blandit','ipsum. Donec sollicitudin','03/08/2016'),('tortor. Integer','Phasellus at augue','01/04/2016');
	INSERT INTO Groups([Name],[Subject],[FromDate]) VALUES('arcu. Curabitur','erat. Vivamus nisi.','09/20/2015'),('ante lectus','lectus, a sollicitudin','08/04/2014'),('non, feugiat','Mauris blandit enim','01/19/2015'),('mattis semper,','malesuada id, erat.','02/09/2015'),('nisi dictum','eget laoreet posuere,','08/01/2014'),('Aliquam auctor,','Morbi quis urna.','07/14/2015'),('et risus.','convallis, ante lectus','03/16/2016'),('Vivamus non','erat. Sed nunc','10/24/2015'),('Nunc mauris','porttitor vulputate, posuere','03/12/2016'),('Sed diam','auctor quis, tristique','03/31/2016');

END

IF(@DummyEnrollments = 1)
BEGIN
	INSERT INTO Enrollments(GroupId, StudentId)
	SELECT DISTINCT G.GroupId,S.StudentId 
	FROM Students S
		INNER JOIN Groups G
		ON StudentId = GroupId
			OR StudentId % 50 = GroupId
			OR StudentId *3 % 50 = GroupId
			OR StudentId *9 % 50 = GroupId
			OR StudentId * 123 % 50 = GroupId
			OR StudentId * 352 % 50 = GroupId
END

IF(@DummyTeachings = 1)
BEGIN
	INSERT INTO Teachings
	SELECT  G.GroupId, U.UserId
	FROM Groups G
		INNER JOIN Users U
			ON G.GroupId = U.UserId
				OR G.GroupId * 123  % 89 = U.UserId
				OR G.GroupId * 12325  % 89 = U.UserId
				OR G.GroupId * 321  % 89 = U.UserId
				OR G.GroupId * 567  % 89 = U.UserId
				OR G.GroupId * 98  % 89 = U.UserId
				OR G.GroupId * 89  % 89 = U.UserId
				OR G.GroupId * 6  % 89 = U.UserId
				OR G.GroupId * 99  % 89 = U.UserId
	WHERE U.[Type] = 'S'
END


DECLARE @Gid INT = 3,
		@Sid INT = 1

IF(@DummyQuestions = 1)
BEGIN

	DECLARE @Qid INT

	INSERT INTO [dbo].[Questions]([SchoolUserId],[GroupId],[Text],[ExpirationDate],[CreationDate])
	VALUES(@Sid,@Gid,'¿Qué opina de la tarea de español?',DATEADD(day,15, GETDATE()),GETDATE())

	SET @Qid = SCOPE_IDENTITY()

	INSERT INTO PossibleAnswers
	VALUES (@Qid,0,'Era sencilla'),(@Qid,1,'No se realizó'),(@Qid,2,'Resultó difícil')

	insert into Answers (StudentId, QuestionId)
	select StudentId,@Qid
	FROM Enrollments where GroupId = @Gid

	INSERT INTO [dbo].[Questions]([SchoolUserId],[GroupId],[Text],[ExpirationDate],[CreationDate])
	VALUES(@Sid,@Gid,'¿Qué de la salida a Chapultepec el 7 de Agosto?',DATEADD(day,15, GETDATE()),GETDATE())

	SET @Qid = SCOPE_IDENTITY()

	INSERT INTO PossibleAnswers
	VALUES (@Qid,0,'Estoy de acuerdo'),(@Qid,1,'No estoy de acuerdo')

	INSERT INTO Answers (StudentId, QuestionId)
	select StudentId,@Qid
	FROM Enrollments where GroupId = @Gid

	INSERT INTO [dbo].[Questions]([SchoolUserId],[GroupId],[Text],[ExpirationDate],[CreationDate])
	VALUES(@Sid,@Gid,'¿Qué día debe llevarse a cabo el festival de día de las madres?',DATEADD(day,15, GETDATE()),GETDATE())

	SET @Qid = SCOPE_IDENTITY()

	INSERT INTO PossibleAnswers
	VALUES (@Qid,0,'9 de mayo'),(@Qid,1,'12 de mayo'),(@Qid,2,'13 de mayo'),(@Qid,3,'No debe haber festival')

	INSERT INTO Answers (StudentId, QuestionId)
	select StudentId,@Qid
	FROM Enrollments where GroupId = @Gid

END

IF (@DummyEvents = 1)
BEGIN

	DECLARE @Eid INT

	INSERT INTO [dbo].[Events]([SchoolUserId],[GroupId],[Name],[Date],[CreationDate],[Description])
	VALUES
			   (@Sid,@Gid
			   ,'Recaudación de firmas para para el tope'
			   ,DATEADD(DAY, 5,GETDATE()),GETDATE()
			   ,'Se recaudarán firmas en la escuela para solicitar la colocación de un tope en la esquina de la escuela para evitar accidentes')
	
	SET @Eid = SCOPE_IDENTITY()

	INSERT INTO Invitations (StudentId, EventId)
	select StudentId,@Eid
	FROM Enrollments where GroupId = @Gid


	INSERT INTO [dbo].[Events]([SchoolUserId],[GroupId],[Name],[Date],[CreationDate],[Description])
	VALUES
			   (@Sid,@Gid
			   ,'Junta para entrega de calificaciones'
			   ,DATEADD(DAY, 20,GETDATE()),GETDATE()
			   ,'Es la junta bimestral de entrega y firma de boletas')
	
	SET @Eid = SCOPE_IDENTITY()

	INSERT INTO Invitations (StudentId, EventId)
	select StudentId,@Eid
	FROM Enrollments where GroupId = @Gid


	INSERT INTO [dbo].[Events]([SchoolUserId],[GroupId],[Name],[Date],[CreationDate],[Description])
	VALUES
			   (@Sid,@Gid
			   ,'Ayúdanos a limpiar la escuela'
			   ,DATEADD(DAY, 30,GETDATE()),GETDATE()
			   ,'Trae un producto de limpieza y un utiensilio para ayudarnos a limpiar la escuela, por los problemas de la semana pasada no tuvimos servicio de limipieza.')
	
	SET @Eid = SCOPE_IDENTITY()

	INSERT INTO Invitations (StudentId, EventId)
	select StudentId,@Eid
	FROM Enrollments where GroupId = @Gid

END


IF (@DummyNotifications = 1)
BEGIN

	INSERT INTO [dbo].[Notifications]([SchoolUserId],[GroupId],[CreationDate],[Text])
		 VALUES
			   (@Sid,@Gid,GETDATE(),
			   'No habrá clases el día 9 de mayo de 2015'),
			   (@Sid,@Gid,GETDATE(),
			   'Tarea de español para el viernes'),
			   (@Sid,@Gid,GETDATE(),
			   'Recuerden comprar los materiales para la maqueta')


	insert into NotificationDetails(StudentId, NotificationId,Seen)
	select E.StudentId,N.NotificationId,0
	from Enrollments E
		inner join Notifications N
		on E.GroupId = N.GroupId

END 