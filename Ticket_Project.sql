CREATE TABLE Users (
    userId SERIAL PRIMARY KEY,
    userName VARCHAR(50) NOT NULL,
    upassword VARCHAR(50) NOT NULL
);

INSERT INTO Users (userName,upassword) VALUES ('daphne','Ddbuse1.');
INSERT INTO Users (userName,upassword) VALUES ('daphne','Ddbuse1.');
INSERT INTO Users (userName,upassword)VALUES
('ali_yilmaz', 'Al1!_Y1lm@z'),
('ayse_kara', 'Ay$e_K@r@4'),
('emre_ozturk', 'Emr3_0zturk!'),
('sevim_demir', 'S3vim_D3m!r'),
('mehmet_ekinci', 'M3hm3t_Ek!nci'),
('gizem_yildiz', 'G!z3m_Y!ldiz'),
('burak_acar', 'Bu1r@k_Ac@r!'),
('elif_celik', '3l!f_C3l!k'),
('tolga_koc', 'T0lga_K0c_123'),
('selin_yavuz', 'S3lin_Y@vuz!'),
('serkan_tekin', 'S3rk@n_T3kin@2023'),
('aylin_kilic', 'Ayl1n_K1l1ç'),
('kerem_yilmaz', 'K3r3m_Y!lm@z'),
('seda_ozturk', 'Sed@_0zturk_2023'),
('onur_celik', '0nur_C3l!k!'),
('ebru_ergin', 'Ebru_Er9!n'),
('mert_genc', 'M3rt_G3nç!'),
('gulsen_ozdemir', 'Güls3n_0zd3m!r'),
('baris_kaya', 'Bar!ş_K@y@_567'),
('sevgi_demirci', 'S3vgi_D3m!rc!'),
('alp_uzun', 'Alp_Uzun@2022'),
('merve_ates', 'Merv3_At3ş!_2023'),
('sibel_kocak', 'S1bel_K0c@k!'),
('kadir_orman', 'K@d1r_0rm@n'),
('nihan_yildirim', 'Nih@n_Y1ld1r!m'),
('alper_yavuz', 'Alp3r_Y@vuz'),
('eda_ozkan', '3d@_0Pzk@n_2023'),
('umut_cakir', 'U7m!t_Çak!r!'),
('sevda_kaya', 'S3vd@_K@y@567'),
('tuncay_aydin', 'Tunc@y_Ayd1n!'),
('cansu_ozdemir', 'C@nsu_0zd3mir'),
('serdar_dogan', 'S3rd@r_D0ğ@n_2022'),
('aysegul_yilmaz', 'Ayş3gül_Y1lm@z@2023'),
('ahmet_kara', 'Ahm3t_K@r@45'),
('ece_demir', 'Ece_D3mir@2023'),
('mert_ozdemir', 'Mert_0zd3mir!'),
('esra_kaya', 'Esra_K@y@789'),
('murat_yilmaz', 'Mur@t_Y1lm@z!'),
('gulay_kurt', 'Gülay_Kurt2022'),
('ayhan_ozturk', 'Ayhan_0zturk@2023'),
('irem_cetin', 'Ir3m_C3t!n!'),
('ali_koc', 'Al!_K0c@123'),
('sevim_yilmaz', 'S3vim_Y!lm@z_2023'),
('okan_aydin', '0kan_Ayd1n!'),
('melis_ozkan', 'M3lis_0zk@n'),
('serhat_dogan', 'S3rhat_D0ğ@n_45'),
('nur_kara', 'Nur4_K@r@!');


CREATE TABLE Manager (
    managerId SERIAL PRIMARY KEY,
    managerUserName VARCHAR(50) NOT NULL,
    mpassword VARCHAR(50) NOT NULL
);

INSERT INTO Manager (managerUserName,mpassword) VALUES ('ibrahim','Can1312*');
INSERT INTO Manager (managerUserName,mpassword) VALUES
('merve_erdem', 'M3rv3_Erd3m!'),
('taner_yilmaz', 'Tan3r_Y!lm@z'),
('aylin_celik', 'Ayl1n_C3l!k!'),
('onur_aktas', '0nur_Akt@ş_2023'),
('yagmur_genc', 'Yağm!r_G3nç@45'),
('burak_yildirim', 'Bur@k_Y1ld1r!m'),
('selin_ozkan', 'S3lin_0zk@n!'),
('gokhan_kaya', 'G0khan_K@y@123'),
('selin_tekin', 'S3lin_T3k!n!'),
('emre_aslan', '3mr3_Asl@n@2022'),
('elif_ozdemir', 'El!f_0zd3m!r_2023'),
('buse_koc', 'Bu$e_K0ç!'),
('emre_yilmaz', 'Emre_Y!lm@z_789'),
('zeynep_kara', 'Z3yn3p_K@r@'),
('ahmet_tekin', 'Ahm3t_T3k!n@2023'),
('deniz_ozturk', 'D3n!z_0zturk!'),
('sema_yavuz', 'S3m@_Y@vuz@45'),
('murat_erdogan', 'Mur@t_Erd0ğ@n'),
('ece_demir', 'Ec3_D3mir_2022'),
('alp_uzun', 'Alp_Uz7un!'),
('gulsen_ozdemir', 'Guls3n_0zd3m!r@2023'),
('serkan_tekin', 'S3rk@n_T3kin567'),
('berk_arslan', 'B3rk_Arsl@n!'),
('ilayda_ozturk', 'Il@yda_0zturk@2023'),
('kaya_yildirim', 'K@ya_Y1ld1r1m'),
('esra_guler', 'Esra_Gül3r@45'),
('alper_aktas', 'Alp3r_Akt@ş!'),
('elif_yilmaz', 'El!f_Y1lm@z123'),
('mercan_kara', 'M3rc@n_K@r@!'),
('tuna_aslan', 'Tun@_Asl@n567'),
('duygu_erdem', 'Duygu_Erd3m@2022'),
('mert_can', 'M3rt_C@n!'),
('yasemin_ozkan', 'Y@sem!n_0zk@n@2023'),
('sevda_koc', 'S3vd@_K0c!2023'),
('eren_ozkan', 'Er3n_0zk@n@45'),
('melis_demir', 'M3l!s_D3m!r123'),
('emir_aydin', 'E9m!r_Ayd!n!'),
('ayse_kara', 'Ays3_K@r@_567'),
('furkan_yilmaz', 'Furk@n_Y1lm@z!'),
('aslihan_tekin', 'Asl!h@n_T3k!n@2022'),
('kaan_celik', 'Ka@n_C3l!k!'),
('merve_ozturk', 'Merv3_0zturk@45'),
('okan_yavuz', '0k@n_Y@vuz!,@gmail.com'),
('sena_erdem', 'S3n@_Erd3m567');

SELECT COUNT(*) FROM Users WHERE userName = 'userName';
INSERT INTO Users (userName, upassword) VALUES ('userName', 'upassword');

CREATE TABLE ManagerOperations(
	operationID SERIAL PRIMARY KEY,
	managerID INTEGER NOT NULL,
	operationDate DATE DEFAULT CURRENT_DATE,
	operationTime TIME DEFAULT CURRENT_TIME,
	FOREIGN KEY (managerID) REFERENCES Manager (managerID)
);

CREATE TABLE Participants(
	participantID SERIAL PRIMARY KEY
);

CREATE TABLE InformationManager(
	infomanID SERIAL PRIMARY KEY,
	managerName VARCHAR(50) NOT NULL,
	managerID INTEGER NOT NULL,
	companyID VARCHAR(3) NOT NULL,
	branchID VARCHAR(4) NOT NULL,
	managerPhone Phone_number,
	FOREIGN KEY (managerID) REFERENCES Manager (managerID)
	ON UPDATE CASCADE,
	FOREIGN KEY (companyID) REFERENCES Company (companyID),
	FOREIGN KEY (branchID) REFERENCES Branch (branchID)
);

--**************************************************************************************************************

CREATE TABLE Company(
    companyID VARCHAR(3) NOT NULL,
    companyName VARCHAR(25) UNIQUE, 
    companyPhone Phone_number,
    PRIMARY KEY(companyID)
);

INSERT INTO Company (companyID, companyName, companyPhone) VALUES
('ULK', 'Ulusoy', '05551234567'),
('NEV', 'Nevşehir Seyahat', '05339968877'),
('PAU', 'Pamukkale Turizm', '05552446666'),
('ULA', 'Uludağ Seyahat', '05447773888'),
('VAN', 'Van Turizm', '05346665577'),
('MER', 'Merkez Tur', '05251112233'),
('BK7', 'Başkent Turizm','05649871236'),
('ES2', 'Esadaş', '05123697532'),
('SH6', 'Sahil Turizm', '05784120015'),
('SEY', 'Süha Turizm', '05338879999'),
('GAR', 'Gülaras Turizm', '05557776666'),
('ADY', 'Adıyaman Ünal Turizm', '05442221133'),
('AGR', 'Ağrı Tur', '05159998888'),
('ALI', 'Ali Osman Ulusoy Turizm', '05491112233'),
('HAS', 'Has Diyarbakır Turizm', '05554443322'),
('KAR', 'Kars Kalesi Turizm', '05847774455'),
('KES', 'Keşanlılar Seyahat', '05558889909'),
('KIR', 'Kırşehir Şanal Turizm', '05046665555'),
('LUX', 'Lüks Artvin Tur', '05557729999'),
('NIL', 'Nilüfer Turizm', '05448881000'),
('SIN', 'Sinop Birlik Tur', '05559998088'),
('SI1', 'Siirt Diyar Seyahat', '05449997077'),
('STA', 'Star Batman Turizm', '05551100233'),
('VAR', 'Varan Turizm', '05442221130'),
('KK1', 'Trabzon Turizm', '05442221139'),
('MET', 'Manisa Turizm', '05442221139'),
('LUA', 'Lüks Adana Tur', '05053334444');

CREATE TABLE Bus(
	busID VARCHAR(3) NOT NULL,
	--tripID VARCHAR(8),
	plaque Bus_plaque,
	busPhone Phone_number,
	totalSeat INTEGER,
	companyID VARCHAR(3),
	seatNumber INTEGER,
    status VARCHAR(1) DEFAULT 'A',
	UNIQUE(busPhone),
	PRIMARY KEY(busID),
	FOREIGN KEY (companyID) REFERENCES Company (companyID)
	--FOREIGN KEY (tripID) REFERENCES Trip (tripID)
);

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('U12', '35 TUV 987', '05442220133', 29, 'ES2');

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('Q78', '05 XYZ 987', '05123456789', 29, 'NIL');

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('E23', '19 STU 789', '05551112233', 29, 'SH6');

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('R89', '36 KLM 456', '05446667788', 29, 'SEY');

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('C34', '25 DEF 456', '05567891234', 29, 'KAR');

INSERT INTO Bus (busID, plaque,busPhone,totalSeat,companyID) VALUES
('I67', '50 EFG 789', '05445556636', 29, 'KIR');





('D45','KS001', '26 GHI 789', '05345678901', 29, 'SIN'),
('E56','KS002', '36 ABC 123', '05431012233', 29, 'ADY'),
('F67','AN017', '78 XYZ 987', '05554443322', 29, 'KES'),
('H89','KS003', '72 GHI 789', '05448880000', 29, 'STA'),
('I90','KS004', '16 JKL 987', '05559998888', 29, 'VAR'),
('J01','KS005', '01 MNO 456', '05442221133', 29, 'LUX'),
('M34','KS006', '69 VWX 789', '05441112233', 29, 'HAS'),
('N45','KS007', '34 YZA 123', '05334446377', 29, 'STA'),
('O56','AD019', '21 BCD 456', '05553325555', 29, 'LUX'),
('P67','KS008', '14 EFG 789', '05448782222', 29, 'NEV'),
('R89','BU010', '36 KLM 456', '05446667788', 29, 'SEY'),
('T01', 'KS009','35 XYZ 123', '05556663322', 29, 'LUA'),




('V23','KS010','35 WXY 456', '05553334744', 29, 'SIN'),

('X45','AN011', '36 ABC 123', '05559098888', 29, 'GAR'),
('Z67','IZ014', '36 CDE 456', '05236667777', 29, 'ALI'),
('A78','IZ005', '36 FGH 789', '05445556666', 29, 'VAN'),
('B89','KS012', '36 IJK 123', '05553332202', 29, 'ALI'),
('D12','KS013', '37 PQR 456', '05443334404', 29, 'GAR'),

('F34','KS014', '40 VWX 123', '05402221133', 29, 'NIL'),
('G45','KS015' ,'30 YZA 987', '05553834444', 29, 'HAS'),
('H56','KS016' ,'60 BCD 456', '05334446077', 29, 'LUA'),

('J78','KS017', '55 HIJ 123', '05051113322', 29, 'MER'),
('K89','KS018' ,'50 IJK 987', '05041112233', 29, 'LUX'),
('M01', 'KS019','52 PQR 789', '05338889699', 29, 'STA'),
('N12','KS020' ,'63 STU 123', '05446661888', 29, 'ALI'),
('O23', 'KS021','30 VWX 987', '05448882222', 29, 'HAS'),
('P34','KS022' ,'17 YZA 456', '05557076666', 29, 'SH6'),
('Q45', 'KS023','29 BCD 789', '05226667777', 29, 'NIL'),
('R56','KS024' ,'41 EFG 123', '05045556666', 29, 'VAR'),
('T78','KS025' ,'77 KLM 456', '05743334444', 29, 'LUA'),
('T79','KS026' ,'61 TRB 451', '05743334441', 29, 'KK1'),
('T80','KS027' ,'60 TRB 452', '05843334441', 29, 'MET'),
('U89', 'KS028','09 NOP 789', '05434446677', 29, 'VAN');

CREATE TABLE City(
	cityID VARCHAR(2) NOT NULL,
	cityName VARCHAR(20),
	totalStation INTEGER,
	PRIMARY KEY(cityID)
);

INSERT INTO City (cityID,cityName,totalStation) VALUES
('01','Adana',2),
('02', 'Adıyaman', 1),
('03', 'Afyonkarahisar', 1),
('04', 'Ağrı', 1),
('05', 'Amasya', 1),
('06', 'Ankara', 2),
('07', 'Antalya', 1),
('08', 'Artvin', 1),
('09', 'Aydın', 1),
('10', 'Balıkesir', 1),
('11', 'Bilecik', 1),
('12', 'Bingöl', 1),
('13', 'Bitlis', 1),
('14', 'Bolu', 1),
('15', 'Burdur', 1),
('16', 'Bursa', 1),
('17', 'Çanakkale', 1),
('18', 'Çankırı', 1),
('19', 'Çorum', 1),
('20', 'Denizli', 1),
('21', 'Diyarbakır', 2),
('22', 'Edirne', 1),
('23', 'Elazığ', 1),
('24', 'Erzincan', 1),
('25', 'Erzurum', 1),
('26', 'Eskişehir', 1),
('27', 'Gaziantep', 1),
('28', 'Giresun', 1),
('29', 'Gümüşhane', 1),
('30', 'Hakkari', 1),
('31', 'Hatay', 1),
('32', 'Isparta', 1),
('33', 'Mersin', 1),
('34', 'İstanbul', 8),
('35', 'İzmir', 1),
('36', 'Kars', 1),
('37', 'Kastamonu', 1),
('38', 'Kayseri', 1),
('39', 'Kırklareli', 1),
('40', 'Kırşehir', 1),
('41', 'Kocaeli', 1),
('42', 'Konya', 2),
('43', 'Kütahya', 1),
('44', 'Malatya', 1),
('45', 'Manisa', 1),
('46', 'Kahramanmaraş', 1),
('47', 'Mardin', 1),
('48', 'Muğla', 1),
('49', 'Muş', 1),
('50', 'Nevşehir', 1),
('51', 'Niğde', 1),
('52', 'Ordu', 1),
('53', 'Rize', 1),
('54', 'Sakarya', 1),
('55', 'Samsun', 1),
('56', 'Siirt', 1),
('57', 'Sinop', 1),
('58', 'Sivas', 1),
('59', 'Tekirdağ', 1),
('60', 'Tokat', 1),
('61', 'Trabzon', 1),
('62', 'Tunceli', 1),
('63', 'Şanlıurfa', 1),
('64', 'Uşak', 1),
('65', 'Van', 1),
('66', 'Yozgat', 1),
('67', 'Zonguldak', 1),
('68', 'Aksaray', 1),
('69', 'Bayburt', 1),
('70', 'Karaman', 1),
('71', 'Kırıkkale', 1),
('72', 'Batman', 1),
('73', 'Şırnak', 1),
('74', 'Bartın', 1),
('75', 'Ardahan', 1),
('76', 'Iğdır', 1),
('77', 'Yalova', 1),
('78', 'Karabük', 1),
('79', 'Kilis', 1),
('80', 'Osmaniye', 1),
('81', 'Düzce', 1);

CREATE TABLE Platform (
	platformID INTEGER NOT NULL,
	companyID VARCHAR(3),
	cityID VARCHAR(2),
	FOREIGN KEY (companyID) REFERENCES Company (companyID),
	FOREIGN KEY (cityID) REFERENCES City (cityID),
	PRIMARY KEY (platformID)
);

CREATE TABLE Branch(
	branchID VARCHAR(5) NOT NULL,
	stationName VARCHAR(35),
	companyID VARCHAR(5),
	cityID VARCHAR(5),
	FOREIGN KEY (companyID) REFERENCES Company (companyID),
	FOREIGN KEY (cityID) REFERENCES City (cityID),
	PRIMARY KEY(branchID)
);

INSERT INTO Branch (branchID,stationName,companyID,cityID) VALUES
('PG14','Ankara AŞTİ','KK1','06'),
('AK01', 'Adana Otogarı', 'HAS', '01'),
('AN02', 'Ankara AŞTİ', 'NEV', '06'),
('AN03', 'Antalya Otogarı', 'LUX', '07'),
('IS04', 'Isparta Otogarı', 'PAU', '32'),
('GA05', 'Gaziantep Otogarı', 'VAR', '27'),
('IZ06', 'İzmir Otogarı', 'SH6', '35'),
('ES07', 'Eskişehir Otogarı', 'MER', '26'),
('DI08', 'Diyarbakır Otogarı', 'VAN', '21'),
('KA09', 'Kahramanmaraş Otogarı', 'STA', '46'),
('TR10', 'Trabzon Otogarı', 'KK1', '61'),
('ES11', 'Eskişehir Terminal', 'LUX', '26'),
('IS12', 'Istanbul Esenler Otogarı', 'PAU', '34'),
('BE13', 'Beylikdüzü Otogarı', 'VAR', '34'),
('TR14', 'Trabzon Otogarı', 'SEY', '61'),
('AN15', 'Ankara AŞTİ', 'ULA', '06'),
('AL16', 'Alanya Otogarı', 'PAU', '07'),
('AN17', 'Antakya Otogarı', 'SI1', '31'),
('AD18', 'Adapazarı Otogarı', 'SIN', '54'),
('EL19', 'Elazığ Terminal', 'KAR', '23'),
('AF20', 'Afşin Otogarı', 'KIR', '46'),
('IZ21', 'İzmit Otogarı', 'LUX', '41'),
('UR22', 'Uşak Terminal', 'PAU', '64'),
('MU23', 'Muğla Terminal', 'VAR', '48'),
('DI24', 'Dikili Otogarı', 'BK7', '35'),
('SA25', 'Sakarya Terminal', 'KK1', '54'),
('AD26', 'Aydın Otogarı', 'KK1', '09'),
('GA27', 'Gaziosmanpaşa Otogarı', 'ALI', '34'),
('NE28', 'Nevşehir Terminal', 'NEV', '50'),
('KO29', 'Kocaeli Terminal', 'NIL', '41'),
('YO30', 'Yozgat Otogarı', 'SH6', '66'),
('KO31', 'Konyaaltı Otogarı', 'LUX', '07'),
('GI32', 'Giresun Terminal', 'PAU', '28'),
('TU33', 'Turgutlu Otogarı', 'VAR', '45'),
('OR34', 'Ordu Terminal', 'ULK', '52'),
('NE35', 'Nevşehir Terminal', 'AGR', '50'),
('DI36', 'Diyadin Otogarı', 'LUA', '04'),
('ED37', 'Edremit Terminal', 'SH6', '10'),
('ES38', 'Esenyurt Otogarı', 'VAN', '34'),
('ME39', 'Menemen Terminal', 'ALI', '35'),
('BI40', 'Bilecik Otogarı', 'ALI', '11'),
('KO41', 'Konya Otogarı', 'LUX', '42'),
('DI42', 'Diyarbakır Terminal', 'PAU', '21'),
('VA43', 'Van Otogarı', 'VAR', '65'),
('MU44', 'Muş Terminal', 'ADY', '49'),
('SA45', 'Samsun Otogarı', 'STA', '55'),
('NI46', 'Nigde Terminal', 'ES2', '51'),
('TR47', 'Trakya Terminal', 'KK1', '59'),
('CI48', 'Çorlu Otogarı', 'VAN', '59'),
('KI49', 'Kırşehir Otogarı', 'LUA', '40'),
('AN50', 'Anamur Terminal', 'SH6', '33'),
('BE51', 'Bergama Otogarı', 'LUX', '35'),
('SA52', 'Saray Terminal', 'PAU', '54'),
('UR53', 'Urfa Otogarı', 'VAR', '63'),
('KI54', 'Kırıkhan Terminal', 'ALI', '31'),
('KO55', 'Konya Terminal', 'LUA', '42'),
('IZ56', 'Izmit Terminal', 'KAR', '41'),
('GA57', 'Gazipaşa Otogarı', 'KIR', '07'),
('KA58', 'Kars Otogarı', 'VAN', '36'),
('GO59', 'Gölcük Otogarı', 'ADY', '41'),
('AF60', 'Afyonkarahisar Terminal', 'KK1', '03'),
('KO61', 'Kocaeli Otogarı', 'LUX', '41'),
('DI62', 'Dikmen Terminal', 'PAU', '06'),
('VA63', 'Van Terminal', 'VAR', '65'),
('MU64', 'Muğla Otogarı', 'NIL', '48'),
('SA65', 'Sakarya Terminal', 'SIN', '54'),
('NE66', 'Nevşehir Terminal', 'NEV', '50'),
('KA67', 'Kahramanmaraş Terminal', 'SI1', '46'),
('DI68', 'Diyarbakır Otogarı', 'VAN', '21'),
('ME69', 'Mersin Otogarı', 'SH6', '33'),
('BI70', 'Bilecik Terminal', 'ES2', '11'),
('KO71', 'Konyaaltı Terminal', 'LUX', '07'),
('DI72', 'Diyarbakır Terminal', 'PAU', '21'),
('VA73', 'Van Terminal', 'VAR', '65'),
('MU74', 'Muş Otogarı', 'STA', '49'),
('SA75', 'Samsun Terminal', 'KK1', '55'),
('NI76', 'Niğde Otogarı', 'LUA', '51'),
('TR77', 'Trakya Otogarı', 'MET', '59'),
('CI78', 'Çorlu Terminal', 'VAN', '59'),
('KI79', 'Kırşehir Terminal', 'LUX', '40'),
('AN80', 'Anamur Otogarı', 'AGR', '33'),
('BE81', 'Beylikdüzü Otogarı', 'KK1', '34'),
('LE82', 'Levent Terminal', 'PAU', '34'),
('ME83', 'Merter Otogarı', 'VAR', '34'),
('KI84', 'Küçükçekmece Terminal', 'KK1', '34'),
('KA85', 'Kadıköy Otogarı', 'KK1', '34'),
('US86', 'Üsküdar Terminal', 'BK7', '34'),
('SI87', 'Silivri Otogarı', 'MET', '34'),
('TU88', 'Tuzla Terminal', 'ULK', '34'),
('SA89', 'Sarıyer Terminal', 'MET', '34'),
('SE90', 'Şile Otogarı', 'PAU', '34'),
('IZ10', 'İzmir Otogarı', 'LUX', '35'),
('IZ12', 'İzmir Otogarı', 'SH6', '35'),
('IZ17', 'İzmir Otogarı', 'ES2', '35'),
('IZ23', 'İzmir Otogarı', 'MET', '35');

CREATE TABLE InformationTrip(
    tripID VARCHAR(8) NOT NULL,
    driverID VARCHAR(30) NOT NULL,
    assistantID INTEGER,
    PRIMARY KEY(tripID, driverID),
    FOREIGN KEY(tripID) REFERENCES Trip(tripID) ON UPDATE CASCADE ON DELETE CASCADE,
    FOREIGN KEY(driverID) REFERENCES Drivers(driverID),
    FOREIGN KEY(assistantID) REFERENCES Assistants(assistantID)
);

CREATE TABLE Trip (
    tripID VARCHAR(8),
    busID VARCHAR(8),
    tSource VARCHAR(25),
    tDestination VARCHAR(25),
    tDate DATE,
    sTime TIME,
    dTime TIME,
    price INTEGER,
	totalSeat INTEGER,
    companyName VARCHAR(25),
    PRIMARY KEY(tripID),
    FOREIGN KEY(busID) REFERENCES Bus(busID),
    FOREIGN KEY(companyName) REFERENCES Company(companyName)
);

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('IS008','U12'  ,'Istanbul Esenler Otogarı', 'İzmir Otogarı', '2024-02-05', '15:45', '23:45', 700,29, 'Esadaş');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('AN007','Q78',  'Ankara AŞTİ', 'Gaziantep Otogarı', '2024-02-02', '10:15', '18:15', 750,29, 'Başkent Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('BU010', 'Q78' ,'Ankara AŞTİ', 'Uşak Otogarı', '2024-05-10', '11:00', '19:00', 500,29, 'Başkent Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('IZ016', 'C34','İzmir Otogarı', 'Konyaaltı Terminal', '2024-09-10', '13:45', '21:45', 550,29, 'Kars Kalesi Turizm');




INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('AN017', 'F67' ,'Ankara AŞTİ', 'Afyonkarahisar Terminal', '2024-03-15', '09:15', '17:15', 800,29, 'Keşanlılar Seyahat');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('IS018','I67' ,'Istanbul Esenler Otogarı', 'Van Terminal', '2024-01-20', '15:00', '23:00', 700,29, 'Kırşehir Şanal Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('AD019', 'O56','Adana Otogarı', 'Edremit Terminal', '2024-01-25', '10:30', '18:30', 600,29, 'Lüks Artvin Tur');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS001', 'D45', 'Hatay', 'Manisa Otogarı', '2025-01-20', '10:15', '18:15', 750,29, 'Başkent Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS002', 'E56' ,'Istanbul Dudullu Otogarı', 'Aydın Otogarı', '2024-01-25', '15:45', '23:45', 700,29, 'Esadaş');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS003','H89' ,'Adana Otogarı', 'Trabzonn Otogarı', '2024-01-08', '07:30', '15:30', 550,29, 'Sahil Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS004', 'I90' ,'Iğdır Terminal', 'Uşak Otogarı', '2024-01-10', '11:00', '19:00', 500,29, 'Süha Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS005', 'J01' ,'Polatlı', 'Kırşehir Terminal', '2024-01-15', '08:45', '16:45', 550,29, 'Gülaras Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS006', 'M34' ,'Istanbul Harem Otogarı', 'Gebze Terminal', '2024-01-20', '14:30', '22:30', 450,29, 'Adıyaman Ünal Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS007', 'N45' ,'Balıkesir Otogarı', 'Nevşehir Otogarı', '2024-01-30', '12:15', '20:15', 600,29, 'Ali Osman Ulusoy Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS008', 'P67' ,'Çanakkale Otogarı', 'Konyaaltı Terminal', '2024-02-10', '13:45', '21:45', 550,29, 'Kars Kalesi Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS009','T01' ,'Arpaçay', 'Afyonkarahisar Terminal', '2024-02-15', '09:15', '17:15', 800,29, 'Keşanlılar Seyahat');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS010', 'V23' ,'Istanbul Otogarı', 'Kars Terminal', '2024-02-20', '15:00', '23:00', 700,29, 'Kırşehir Şanal Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS011', 'W34' ,'Sarıkamış Otogarı', 'Antalya Terminal', '2024-02-25', '10:30', '18:30', 600,29, 'Lüks Artvin Tur');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS012',  'B89','Üsküdar Terminal', 'İzmir Otogarı', '2024-03-01', '12:45', '20:45', 650,29, 'Nilüfer Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS013','D12' ,'Ankara AŞTİ', 'Digor Otogarı', '2024-01-18', '10:15', '18:15', 750,29, 'Başkent Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS014', 'F34' ,'Istanbul Esenler Otogarı', 'Burdur Otogarı', '2024-01-16', '15:45', '23:45', 700,29, 'Esadaş');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS015', 'G45' ,'Çekmeköy Otogarı', 'Bornova Otogarı', '2024-01-23', '07:30', '15:30', 550,29, 'Sahil Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS016', 'H56' ,'Aşti Terminal', 'Sarıkamış Otogarı', '2024-01-10', '11:00', '19:00', 500,29, 'Süha Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS017', 'J78' ,'KahramanMaraş', 'Malatya Terminal', '2024-01-15', '08:45', '16:45', 550,29, 'Gülaras Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS018', 'K89' ,'ŞanlıUrfa  Otogarı', 'Esenler Terminal', '2024-01-20', '14:30', '22:30', 450,29, 'Adıyaman Ünal Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS019', 'M01' ,'Artvin Otogarı', 'Kapadokya Otogarı', '2024-01-30', '12:15', '20:15', 600,29, 'Ali Osman Ulusoy Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS020', 'N12' ,'Alsancak', 'Üsküdar Terminal', '2024-02-10', '13:45', '21:45', 550,29, 'Kars Kalesi Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS021',  'O23','Bağcılar', 'Çankaya Terminal', '2024-02-15', '09:15', '17:15', 800,29, 'Keşanlılar Seyahat');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS022', 'P34' ,'Esenyurt Otogarı', 'Van Terminal', '2024-02-20', '15:00', '23:00', 700,29, 'Kırşehir Şanal Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS023', 'Q45' ,'Kadıköy', 'Van Terminal', '2024-02-25', '10:30', '18:30', 600,29, 'Lüks Artvin Tur');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS024','R56' ,'Pendik Terminal', 'Diyarbakır Merkez Otogarı', '2024-03-14', '12:45', '20:45', 650,29, 'Nilüfer Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS025', 'T78','Ümraniye', 'Gaziantep Otogarı', '2024-01-13', '10:15', '18:15', 750,29, 'Başkent Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS026','T79' ,'Sultanbeyli Otogarı', 'Kars', '2024-01-012', '15:45', '23:45', 700,29, 'Esadaş');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS027','T80' ,'Silivri Otogarı', 'Darıca Otogarı', '2024-01-09', '07:30', '15:30', 550,29, 'Sahil Turizm');

INSERT INTO Trip (tripID,busID, tSource, tDestination, tDate, sTime, dTime, price,totalSeat, companyName)
VALUES
('KS028',  'U89','Halkalı Terminal', 'Kastamonu Otogarı', '2024-02-10', '11:00', '19:00', 500,29, 'Süha Turizm');

--**************************************************************************************************************

CREATE TABLE Drivers(
	driverID VARCHAR(30) PRIMARY KEY,
	driverName VARCHAR(30),
	driverPhone Phone_number,
	driverDate DATE,
	driverLicenseNo VARCHAR(15) NOT NULL,
	driverLicenseDate DATE NOT NULL,
	companyName VARCHAR(30) NOT NULL,
	tripID VARCHAR(8),
	staffID INTEGER CHECK (staffID IN (1)),
	FOREIGN KEY (companyName) REFERENCES Company (companyName),
	FOREIGN KEY (staffID) REFERENCES Staff (staffID),
	FOREIGN KEY (tripID) REFERENCES Trip (tripID)
);

INSERT INTO Drivers (driverID, driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID) 
VALUES ('1', 'John Doe', '05353144701', '1980-01-01', 'DL123456', '2027-01-01', 'Esadaş', 'BU010');

INSERT INTO Drivers (driverID, driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID) 
VALUES ('2', ' Doe', '05353144701', '1980-01-01', 'DL123456', '2028-01-01', 'Esadaş', 'BU010');

INSERT INTO Drivers (driverID, driverName, driverPhone, driverDate, driverLicenseNo, driverLicenseDate, companyName, tripID) 
VALUES ('12', 'John Doe', '05353144701', '1990-01-01', 'DL123456', '2020-01-01', 'Esadaş', 'AN007');


CREATE TABLE Assistants(
	assistantID INTEGER PRIMARY KEY,
	assistantName VARCHAR(30),
	assistantPhone Phone_number,
	assistantDate DATE,
	companyName VARCHAR(30) NOT NULL,
	tripID VARCHAR(8),
	staffID INTEGER CHECK(staffID IN (2)),
	FOREIGN KEY (companyName) REFERENCES Company (companyName),
	FOREIGN KEY (staffID) REFERENCES Staff (staffID),
	FOREIGN KEY (tripID) REFERENCES Trip (tripID)
);

INSERT INTO Assistants (assistantID, assistantName, assistantPhone, assistantDate, companyName, tripID) 
VALUES ('8', 'Ibrahim', '05353144708', '1995-01-01', 'Merkez Tur', 'IZ006');

CREATE TABLE Staff(
	staffID SERIAL PRIMARY KEY CHECK (staffID IN (1,2,3)),
	staffWork VARCHAR(10)
);

INSERT INTO Staff (staffWork) VALUES
('Yönetici'),('Şoför'),('Muavin');

--**************************************************************************************************************

CREATE TABLE Passenger (	
	passengerID SERIAL PRIMARY KEY,
    tripID VARCHAR(8),
	busID VARCHAR(3),
    pName VARCHAR(20),
    pLastName VARCHAR(20),
    gender GenderType,
    pTel VARCHAR(15),
    pMail proper_email,
    tSource VARCHAR(25),
    tDestination VARCHAR(25),
    tDate DATE,
    sTime TIME,
    dTime TIME,
    price INTEGER,
	companyName VARCHAR(30),
	seatNumber INTEGER,
    cardNumber Card_Number, 
    cardName VARCHAR(20),
    cardCsv VARCHAR(13),
    cardDate DATE,
    cardtype VARCHAR(30), 	
	FOREIGN KEY (companyName) REFERENCES Company (companyName),
    FOREIGN KEY(tripID) REFERENCES Trip(tripID),
	FOREIGN KEY(busID) REFERENCES Bus(busID)
);


INSERT INTO Passenger (tripID,busID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price,companyName, seatNumber, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('AN007', 'Defne', 'Celik', 'F', '05555555555', 'defne@gmail.com', 'Ankara AŞTİ', 'Gaziantep Otogarı', '2024-02-02', '10:15', '18:15', 450, 'Van Turizm', 20, '1234567890123456', 'John Doe', '123', '2025-11-30', 'Visa');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price,companyName, seatNumber, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('AN007', 'İbrahim', 'Gok', 'M', '05444444444', 'can@gmail.com', 'Ankara AŞTİ', 'Gaziantep Otogarı', '2024-02-02', '10:15', '18:15', 750 ,'Başkent Turizm', 2 , '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, seatNumber, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('AN007', 'Zeynep', 'Aydın', 'F', '05321234567', 'zeynep@gmail.com', 'Ankara AŞTİ', 'Gaziantep Otogarı', '2024-01-02', '10:15', '18:15', 750, 'Van Turizm', 2, '2345678901234567', 'Jane Doe', '456', '2026-12-31', 'MasterCard');

INSERT INTO Passenger (tripID,busID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, seatNumber, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('AN007', 'Q78', 'Mert', 'Yılmaz', 'M', '05439987654', 'mert@gmail.com', 'Ankara AŞTİ', 'Gaziantep Otogarı', '2024-01-02', '10:15', '18:15', 750, 'Van Turizm', 2, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Ayşe', 'Koç', 'F', '05551122334', 'ayse@gmail.com', 'Istanbul Esenler Otogarı', 'İzmir Otogarı', '2024-01-05', '15:45', '23:45', 700, 'Van Turizm', 3, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Emre', 'Arslan', 'M', '05337778899', 'emre@gmail.com', 'Adana Otogarı', 'İzmir  Otogarı', '2024-01-08', '07:30', '15:30', 550, 'Van Turizm', 4, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Gizem', 'Taş', 'F', '05556667788', 'gizem@gmail.com', 'Bursa Terminal', 'Uşak Otogarı', '2024-01-10', '11:00', '19:00', 500, 'Van Turizm', 5, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Büşra', 'Demir', 'F', '05441234567', 'busra@gmail.com','Ankara AŞTİ', 'Kırşehir Terminal', '2024-01-15', '08:45', '16:45', 550, 'Van Turizm', 6, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Okan', 'Ergin', 'M', '05553337788', 'okan@gmail.com', 'Istanbul Esenler Otogarı', 'Sakarya Terminal', '2024-01-20', '14:30', '22:30', 450, 'Van Turizm', 7, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Ceren', 'Kaya', 'F', '05339998877', 'ceren@gmail.com','İzmir Otogarı', 'Nevşehir Otogarı', '2024-01-30', '12:15', '20:15', 600, 'Van Turizm', 8, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Baran', 'Şahin', 'M', '05444445555', 'baran@gmail.com', 'Ankara AŞTİ', 'Osmaniye Otogarı', '2024-02-05', '11:30', '19:30', 700, 'Van Turizm', 9, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Elif', 'Yıldız', 'F', '05556663322', 'elif@gmail.com','İzmir Otogarı', 'KOnyaaltı Terminal', '2024-02-10', '13:45', '21:45', 550, 'Van Turizm', 10, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Deniz', 'Yılmaz', 'F', '05441112233', 'deniz@gmail.com','Ankara AŞTİ', 'Afyonkarahisar Terminal', '2024-02-15', '09:15', '17:15', 800, 'Van Turizm', 11, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Kaan', 'Acar', 'M', '05554446666', 'kaan@gmail.com', 'Istanbul Esenler Otogarı', 'Van Terminal', '2024-02-20', '15:00', '23:00', 700, 'Van Turizm', 12, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

INSERT INTO Passenger (tripID, pName, pLastName, gender, pTel, pMail, tSource, tDestination, tDate, sTime, dTime, price, companyName, numberOfSeats, cardNumber, cardName, cardCsv, cardDate, cardtype)
VALUES
('IZ005', 'Nazlı', 'Doğan', 'F', '05338889999', 'nazli@gmail.com','Adana Otogarı', 'Edremit Terminal', '2024-02-25', '10:30', '18:30', 600, 'Van Turizm', 13, '2345678901234567', 'Jane Doe', '456', '2025-10-31', 'MasterCard');

('Selin', 'Taşkın', 'F', '05551112233', 'selin@gmail.com', '10.11.2000'),
('Kerem', 'Yavuz', 'M', '05448889900', 'kerem@gmail.com', '15.07.1997'),
('Ezgi', 'Öztürk', 'F', '05553334455', 'ezgi@gmail.com', '23.02.1986'),
('Arda', 'Demir', 'M', '05441115233', 'arda@gmail.com', '04.06.1994'),
('İpek', 'Kaya', 'F', '05554447777', 'ipek@gmail.com', '12.01.1999'),
('Umut', 'Sarı', 'M', '05446667788', 'umut@gmail.com', '30.03.1983'),
('Burak', 'Aksoy', 'M', '05557778899', 'burak@gmail.com', '18.09.1990'),
('Sevgi', 'Güler', 'F', '05443332211', 'sevgi@gmail.com', '27.04.1995'),
('Tolga', 'Kurt', 'M', '05556167788', 'tolga@gmail.com', '05.12.1988'),
('Aslı', 'Çetin', 'F', '05445556677', 'asli@gmail.com', '09.03.1992'),
('Efe', 'Aydın', 'M', '05442221133', 'efe@gmail.com', '14.06.1987'),
('ibo', 'can', 'F', '05442221130', 'ibo@gmail.com', '14.06.1987');

--***************************************************************************************************************

CREATE TABLE Costs (
    costID SERIAL PRIMARY KEY,
    busID VARCHAR(10) NOT NULL,
    costTypeID INTEGER NOT NULL,
    costType VARCHAR(50),
    totalCost INTEGER,
    FOREIGN KEY (busID) REFERENCES Bus (busID)
);

CREATE TYPE cost_type AS ENUM (
    'Benzin',
    'Kek',
    'Kolonya',
    'Kahve',
    'Çay',
    'Kola',
    'Soda',
    'Küçük Atıştırmalıklar'
);

INSERT INTO Costs (busID, costTypeID, costType, totalCost)
VALUES 
       ('B23', 2, 'Benzin', 300),
       ('B23', 2, 'Kek', 100);
	   
	   
CREATE TABLE costTypes(
	costTypeID SERIAL PRIMARY KEY,
	costType VARCHAR(10)
);	   

INSERT INTO Costs (busID, costTypeID, costType, totalCost)
VALUES ('B23', 2, 'Benzin', 300);

INSERT INTO Costs (busID, costTypeID, costType, totalCost)
VALUES ('B23', 2, 'Kola', 600);

--***************************************************************************************************************

CREATE TABLE Seat (
    seatNumber INTEGER PRIMARY KEY,
    busID VARCHAR(8) REFERENCES Bus(busID),
    status VARCHAR(1) DEFAULT 'A'
);

CREATE TABLE Tickets(
	ticketID SERIAL PRIMARY KEY,
	numberOfSeats INTEGER CHECK (numberOfSeats<=29),
	passengerID INTEGER,
	tripID VARCHAR(5),
	FOREIGN KEY (numberOfSeats) REFERENCES Seat (numberOfSeats),
	FOREIGN KEY (passengerID) REFERENCES Passenger (passengerID),
	FOREIGN KEY (tripID) REFERENCES Trip (tripID)
);

--***************************************************************************************************************

CREATE TABLE Payments (
    paymentID SERIAL PRIMARY KEY,
    passengerID INTEGER NOT NULL,
    cardNumber Card_Number NOT NULL,
    cardName VARCHAR(20),
    cardCsv VARCHAR(3) NOT NULL,
    cardDate DATE NOT NULL,
    cardtype VARCHAR(7),
    paymentTime TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    UNIQUE(cardNumber),
    FOREIGN KEY (passengerID) REFERENCES Passenger (passengerID)
);