﻿DECLARE @CurrentMigration [nvarchar](max)

IF object_id('[dbo].[__MigrationHistory]') IS NOT NULL
    SELECT @CurrentMigration =
        (SELECT TOP (1) 
        [Project1].[MigrationId] AS [MigrationId]
        FROM ( SELECT 
        [Extent1].[MigrationId] AS [MigrationId]
        FROM [dbo].[__MigrationHistory] AS [Extent1]
        WHERE [Extent1].[ContextKey] = N'IntranetRosul.Migrations.Configuration'
        )  AS [Project1]
        ORDER BY [Project1].[MigrationId] DESC)

IF @CurrentMigration IS NULL
    SET @CurrentMigration = '0'

IF @CurrentMigration < '201610051703438_Initial'
BEGIN
    DROP TABLE [dbo].[Categorias]
    CREATE TABLE [dbo].[__MigrationHistory] (
        [MigrationId] [nvarchar](150) NOT NULL,
        [ContextKey] [nvarchar](300) NOT NULL,
        [Model] [varbinary](max) NOT NULL,
        [ProductVersion] [nvarchar](32) NOT NULL,
        CONSTRAINT [PK_dbo.__MigrationHistory] PRIMARY KEY ([MigrationId], [ContextKey])
    )
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201610051703438_Initial', N'IntranetRosul.Migrations.Configuration',  0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CD919CC1AED044EDBCE1A3BB607D39E206F065B62B785912845A21C1B8B7C591EF249F9852DEACE9B2E2D59DD0E06185862F154B158248BA5AAFEF3F73FE6DF3FFB9EF184A3D80DC89979343B340D4CECC071C9E6CC4CE8FADB0FE6F7DFFDFD6FF34BC77F367E2AE84E181DF424F199F94869786A59B1FD887D14CF7CD78E823858D3991DF8167202EBF8F0F0DFD6D1918501C2042CC3987F4E08757D9C3EC0E32220360E6982BC9BC0C15E9CBF8796658A6ADC221FC721B2F199794D688408A69F8338F16619BD699C7B2E025996D85B9B062224A08882A4A75F62BCA4514036CB105E20EFFE25C440B7465E8CF3119C56E45D077378CC0663551D0B283B8969E0F7043C3AC9B56389DDB7D2B1596A0FF477097AA62F6CD4A90E417D0E4E5F7D0E3C5080C8F074E1458CF8CCBC29599CC7E12DA6B3A2E32C83BC8A00EED720FA3AAB231E189DFB1D94D6743C3B64FF0E8C45E2D124C267042730C7DE81F1295979AEFD5FFC721F7CC5E4ECE468B53EF9F0EE3D724EDEFF0B9FBCAB8F14C60A74DC0B78F5290A421C816C785D8EDF342CBE9F25762CBBD5FA645A015B8285611A37E8F923261BFA084BE6F883695CB9CFD829DEE4C6F585B8B08EA0138D1278BC4D3C0FAD3C5CB65B8D3CD9FF0D5C8FDFBD1F85EB2D7A7237E9D40BFC61E144B0AE3E632F6D8D1FDD305B5EDC7C3FE4645751E0B367DEBEB2D687659044361B4CA025B947D106535EBAB955196F27936650E39B7581BAFFA6CD2495CD5B49CA06B4CD4A28584CBD1A0A795F976F678B3B0F4398BCD4B498469A0C4E755CCD84FE0706475599CF5157F32130ACBFF26EF829026F217AB80DFC55D4B42DC29F9DD837735BE24D429C602A76F9E0CE43EC79AE134C36BCC91802E503F6430FA38A1958FCC9716F3BB8F491EB8D702C76E0023EE9DA8D7C5C5AFB0F016C4288F4B75D14C7702A38FF41F1E304736B27116C564B8AFCF0F52DF73120F836F1576C0F9C8ED7685373FF6B70856C1A449784F51A8CF731B0BF0609BD24CE05A2F80BB50B40F678EFFADD014611E7DCB6711C5F8131636711C0956BD8E26347D5AEDDD285875C5FED970A87EA43415AF9A66A0AC93FD590A97CD426513F061B977413B520D58B9A51B48A9A93F5159581759334A7D40B9A12B4CA99518DE6F5A73334BEDB9FC2EEBFDF3FCC89D3ED0535352E6187C43F628223D8C69C4F88521C916A06BAEC1BBB701AD3E9634C5FFD6C4A39FD84BC646C565BAD867413187F35A4B0FBBF1A5231E1F593EB30AFA4C365B82006F84EF4EA7B76FB9A13249BFE0E551BE6D4CCA7D90374CBE53C8E03DB4D5781220C9A07B178F9C18733DA235AD968C4A8180C0C0CDD65471EBC81B199A251DD910BEC618A8D733B0B132F506C234756230CC8E9215871A22A04ABA263BC70FF947882A5E3887542EC1214C34A75099597854B6C37445EAB96849E1D8F3036F69287D87281434C18C3564D7461AE0E8631014A3EC2A4B469686ED52CAED910355EAB6ECEDB5CD86ADEA518D52436D9E23B6BEC32F7DF5EC5309B3536817136ABA48B00DAC0EE2E0C34BFAB743500F1E2B26F062ADC9834069ABB54931828AFB11D1828AF923767A0D915B5EBFC0BF7D57D334FFEA23CFDB1DEA8AE1DD826A78F3D33CDCCF7843E147AE04836CF8B156BC4CF5471390339F3FB599CBBBAA28930F025A67CC8A6F277957EA8D50C221A51136065682DA0F9276109485A503D842B62798DD2E55E440FD822EED6089BEFFD026CCD0664ECFAA7F11AA1FE03BA689C9D6E1FE5C84A6B908CBCD365A186A3300871F3E207DE4129BAB8ACAC982EBE701F6FB836B07C321A14D4E2B96A94540C66742D15A6D9AE259543D6C7251BA425C17DD268A918CCE85ACA6DB45D490AA7A0875B304845FC113ED2622B221DE56953B6CDAD2C672E7F31B734C975F31B14862ED9D492EDF237C632CBB45B7CBBEC9F80E66718961D2BF2D04A694B4E3488D0060BADC01A24BD72A3985E208A5688C579168E2F9129CF56CDF65FB0AC1F9FF22416E74041CDFECEF77655220777DACAEE488E720563F4994F9306D21516A0EE6EB0F447E4A14811BB5F045EE213BD8BA5EF9D7DC1ABF7CFDEC808734B905F72A1247D498E2EAFFC4E53232F8BD1A6A9F461B69F2A3D844EE185075A57B9CE2BD5A31441AA3A8A2E70B5B3A9D339333DA74BF414FBCF562BC2EBAC2D214DA90E243475C7149391EAA0625B6F49AB142085AC55637F69D5C0726B77643E89A88ECAB77447CC9389EA50F9AB9E18B57C1409ACD6D66376B894216E6AB8963EF3C2E505F193C235F590B29EFDC309596FD80A4FA3513545770E72BE4F1D5D6EED8EACC8FCA9432B9AB7C056C82CB67547552407D58115CDDDB1AB4C21F1D0DB635F437BDB1CE06C64218961DE8606E3754EB0719C955AE6451DA8F6BA27569E5B2181E5EFF7D29EB4F7F201F694C5A286D9930643BFFB70590BFCE6D3986AA1C7E4521178CFA32115438FD7CF6A5FD536A48BB94852722F2FE8C2457C9E5F8ADB4BE1A45B7246621A851AE1707F8929F6678C60B6FCC55B782E665B7941708388BBC631CDD26F4CB8C47F106AE9F6A7AECD8A63C753041574C56DFC9C4D9049479E50643FA248CE6B1950FB55814A9F0CAE89839FCFCCFFA5BD4ED3E813FB2B7D7D605CC75F88FB4B020DF751828DDFE43CDD716A619A2FC67B5AB9D45DABD73F3F645D0F8CBB0856CCA97128E8729B19E6EB997A4993751D20CDD6554E6F774129CB870AF46F7CF4FC8F3AE4F625428320356540A388392AA8AA9CC765A7CA90621EE55C0BDBD4F6B53B2BB7BF78AABA9D8193A1A8CD19663272FDCD5878A3A850575FB30D96B6B6C681479AD6D6F41BACBAD6661BD1B47536DBAC0AB1CAA6FBE150F4DCA103A0B8AB4E7150A47A6EAD521894B2BC6B8F412A6618B4D0E582851E70038A12B6B08C3796CF3FA2CF22A5EB8F86BD4BD37EF51CFD7D49CBAF12A6769B8D3F65027EC307D6BF54DEFD1E648A2A32DF769F5D3FB5ADE9E2EB7B9EA2DC2F877ECF8C2DCF87DC7DA6FCD4C6A60BBEEFB9B1F5CA87DF335BDBD5F9B9634BEB7C84EE3CBB5D4ED4D37C275345E8DBB2D7B3CF1970C35FB13853E6516645C7EA74C9A654EF168615899EA93E4F53642C2D1C89AF44D1CCB6DF58F303BF71B0394D335B4D767313EF7CFF6FE49DD334F3D6E40CEF22EF5E99B5ABAA8568D9C79AD209DF529E3D379296B28E369FB531E9E12DA5D58FA2146EF568BEDCBF9D2CFA515432E6D2E991352F7F8487B3B3F6ABB5707EC7EEA68260BF614BB0CD9D9A25CD355907C5E12D48549008119A1B4C910347EA7944DD35B22934B31873FAAB0969DC8E7DE95861E79ADC25344C280C19FB2B8F0B783127A0897F5A1AC0CB3CBF0BD31F001A630820A6CB62F377E487C4F59C52EE2B454C4803C1BC8B3CA2CBE692B2C8EEE6A544BA0D4847A05C7DA55374CFBE5F01587C4796E8096F231B98DF47BC41F64B1501D481B44F04AFF6F9858B3611F2E31CA3EA0F8F60C38EFFFCDDFF01A89B5422BC590000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201610051704508_Categorias'
BEGIN
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201610051704508_Categorias', N'IntranetRosul.Migrations.Configuration',  0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CD919CC1AED044EDBCE1A3BB607D39E206F065B62B785912845A21C1B8B7C591EF249F9852DEACE9B2E2D59DD0E06185862F154B158248BA5AAFEF3F73FE6DF3FFB9EF184A3D80DC89979343B340D4CECC071C9E6CC4CE8FADB0FE6F7DFFDFD6FF34BC77F367E2AE84E181DF424F199F94869786A59B1FD887D14CF7CD78E823858D3991DF8167202EBF8F0F0DFD6D1918501C2042CC3987F4E08757D9C3EC0E32220360E6982BC9BC0C15E9CBF8796658A6ADC221FC721B2F199794D688408A69F8338F16619BD699C7B2E025996D85B9B062224A08882A4A75F62BCA4514036CB105E20EFFE25C440B7465E8CF3119C56E45D077378CC0663551D0B283B8969E0F7043C3AC9B56389DDB7D2B1596A0FF477097AA62F6CD4A90E417D0E4E5F7D0E3C5080C8F074E1458CF8CCBC29599CC7E12DA6B3A2E32C83BC8A00EED720FA3AAB231E189DFB1D94D6743C3B64FF0E8C45E2D124C267042730C7DE81F1295979AEFD5FFC721F7CC5E4ECE468B53EF9F0EE3D724EDEFF0B9FBCAB8F14C60A74DC0B78F5290A421C816C785D8EDF342CBE9F25762CBBD5FA645A015B8285611A37E8F923261BFA084BE6F883695CB9CFD829DEE4C6F585B8B08EA0138D1278BC4D3C0FAD3C5CB65B8D3CD9FF0D5C8FDFBD1F85EB2D7A7237E9D40BFC61E144B0AE3E632F6D8D1FDD305B5EDC7C3FE4645751E0B367DEBEB2D687659044361B4CA025B947D106535EBAB955196F27936650E39B7581BAFFA6CD2495CD5B49CA06B4CD4A28584CBD1A0A795F976F678B3B0F4398BCD4B498469A0C4E755CCD84FE0706475599CF5157F32130ACBFF26EF829026F217AB80DFC55D4B42DC29F9DD837735BE24D429C602A76F9E0CE43EC79AE134C36BCC91802E503F6430FA38A1958FCC9716F3BB8F491EB8D702C76E0023EE9DA8D7C5C5AFB0F016C4288F4B75D14C7702A38FF41F1E304736B27116C564B8AFCF0F52DF73120F836F1576C0F9C8ED7685373FF6B70856C1A449784F51A8CF731B0BF0609BD24CE05A2F80BB50B40F678EFFADD014611E7DCB6711C5F8131636711C0956BD8E26347D5AEDDD285875C5FED970A87EA43415AF9A66A0AC93FD590A97CD426513F061B977413B520D58B9A51B48A9A93F5159581759334A7D40B9A12B4CA99518DE6F5A73334BEDB9FC2EEBFDF3FCC89D3ED0535352E6187C43F628223D8C69C4F88521C916A06BAEC1BBB701AD3E9634C5FFD6C4A39FD84BC646C565BAD867413187F35A4B0FBBF1A5231E1F593EB30AFA4C365B82006F84EF4EA7B76FB9A13249BFE0E551BE6D4CCA7D90374CBE53C8E03DB4D5781220C9A07B178F9C18733DA235AD968C4A8180C0C0CDD65471EBC81B199A251DD910BEC618A8D733B0B132F506C234756230CC8E9215871A22A04ABA263BC70FF947882A5E3887542EC1214C34A75099597854B6C37445EAB96849E1D8F3036F69287D87281434C18C3564D7461AE0E8631014A3EC2A4B469686ED52CAED910355EAB6ECEDB5CD86ADEA518D52436D9E23B6BEC32F7DF5EC5309B3536817136ABA48B00DAC0EE2E0C34BFAB743500F1E2B26F062ADC9834069ABB54931828AFB11D1828AF923767A0D915B5EBFC0BF7D57D334FFEA23CFDB1DEA8AE1DD826A78F3D33CDCCF7843E147AE04836CF8B156BC4CF5471390339F3FB599CBBBAA28930F025A67CC8A6F277957EA8D50C221A51136065682DA0F9276109485A503D842B62798DD2E55E440FD822EED6089BEFFD026CCD0664ECFAA7F11AA1FE03BA689C9D6E1FE5C84A6B908CBCD365A186A3300871F3E207DE4129BAB8ACAC982EBE701F6FB836B07C321A14D4E2B96A94540C66742D15A6D9AE259543D6C7251BA425C17DD268A918CCE85ACA6DB45D490AA7A0875B304845FC113ED2622B221DE56953B6CDAD2C672E7F31B734C975F31B14862ED9D492EDF237C632CBB45B7CBBEC9F80E66718961D2BF2D04A694B4E3488D0060BADC01A24BD72A3985E208A5688C579168E2F9129CF56CDF65FB0AC1F9FF22416E74041CDFECEF77655220777DACAEE488E720563F4994F9306D21516A0EE6EB0F447E4A14811BB5F045EE213BD8BA5EF9D7DC1ABF7CFDEC808734B905F72A1247D498E2EAFFC4E53232F8BD1A6A9F461B69F2A3D844EE185075A57B9CE2BD5A31441AA3A8A2E70B5B3A9D339333DA74BF414FBCF562BC2EBAC2D214DA90E243475C7149391EAA0625B6F49AB142085AC55637F69D5C0726B77643E89A88ECAB77447CC9389EA50F9AB9E18B57C1409ACD6D66376B894216E6AB8963EF3C2E505F193C235F590B29EFDC309596FD80A4FA3513545770E72BE4F1D5D6EED8EACC8FCA9432B9AB7C056C82CB67547552407D58115CDDDB1AB4C21F1D0DB635F437BDB1CE06C64218961DE8606E3754EB0719C955AE6451DA8F6BA27569E5B2181E5EFF7D29EB4F7F201F694C5A286D9930643BFFB70590BFCE6D3986AA1C7E4521178CFA32115438FD7CF6A5FD536A48BB94852722F2FE8C2457C9E5F8ADB4BE1A45B7246621A851AE1707F8929F6678C60B6FCC55B782E665B7941708388BBC631CDD26F4CB8C47F106AE9F6A7AECD8A63C753041574C56DFC9C4D9049479E50643FA248CE6B1950FB55814A9F0CAE89839FCFCCFFA5BD4ED3E813FB2B7D7D605CC75F88FB4B020DF751828DDFE43CDD716A619A2FC67B5AB9D45DABD73F3F645D0F8CBB0856CCA97128E8729B19E6EB997A4993751D20CDD6554E6F774129CB870AF46F7CF4FC8F3AE4F625428320356540A388392AA8AA9CC765A7CA90621EE55C0BDBD4F6B53B2BB7BF78AABA9D8193A1A8CD19663272FDCD5878A3A850575FB30D96B6B6C681479AD6D6F41BACBAD6661BD1B47536DBAC0AB1CAA6FBE150F4DCA103A0B8AB4E7150A47A6EAD521894B2BC6B8F412A6618B4D0E582851E70038A12B6B08C3796CF3FA2CF22A5EB8F86BD4BD37EF51CFD7D49CBAF12A6769B8D3F65027EC307D6BF54DEFD1E648A2A32DF769F5D3FB5ADE9E2EB7B9EA2DC2F877ECF8C2DCF87DC7DA6FCD4C6A60BBEEFB9B1F5CA87DF335BDBD5F9B9634BEB7C84EE3CBB5D4ED4D37C275345E8DBB2D7B3CF1970C35FB13853E6516645C7EA74C9A654EF168615899EA93E4F53642C2D1C89AF44D1CCB6DF58F303BF71B0394D335B4D767313EF7CFF6FE49DD334F3D6E40CEF22EF5E99B5ABAA8568D9C79AD209DF529E3D379296B28E369FB531E9E12DA5D58FA2146EF568BEDCBF9D2CFA515432E6D2E991352F7F8487B3B3F6ABB5707EC7EEA68260BF614BB0CD9D9A25CD355907C5E12D48549008119A1B4C910347EA7944DD35B22934B31873FAAB0969DC8E7DE95861E79ADC25344C280C19FB2B8F0B783127A0897F5A1AC0CB3CBF0BD31F001A630820A6CB62F377E487C4F59C52EE2B454C4803C1BC8B3CA2CBE692B2C8EEE6A544BA0D4847A05C7DA55374CFBE5F01587C4796E8096F231B98DF47BC41F64B1501D481B44F04AFF6F9858B3611F2E31CA3EA0F8F60C38EFFFCDDFF01A89B5422BC590000 , N'6.1.3-40302')
END

IF @CurrentMigration < '201610051713062_Categorias1'
BEGIN
    INSERT [dbo].[__MigrationHistory]([MigrationId], [ContextKey], [Model], [ProductVersion])
    VALUES (N'201610051713062_Categorias1', N'IntranetRosul.Migrations.Configuration',  0x1F8B0800000000000400DD5CDB6EE436127D5F60FF41D05376E1B47CD919CC1AED044EDBCE1A3BB607D39E206F065B62B785912845A21C1B8B7C591EF249F9852DEACE9B2E2D59DD0E06185862F154B158248BA5AAFEF3F73FE6DF3FFB9EF184A3D80DC89979343B340D4CECC071C9E6CC4CE8FADB0FE6F7DFFDFD6FF34BC77F367E2AE84E181DF424F199F94869786A59B1FD887D14CF7CD78E823858D3991DF8167202EBF8F0F0DFD6D1918501C2042CC3987F4E08757D9C3EC0E32220360E6982BC9BC0C15E9CBF8796658A6ADC221FC721B2F199794D688408A69F8338F16619BD699C7B2E025996D85B9B062224A08882A4A75F62BCA4514036CB105E20EFFE25C440B7465E8CF3119C56E45D077378CC0663551D0B283B8969E0F7043C3AC9B56389DDB7D2B1596A0FF477097AA62F6CD4A90E417D0E4E5F7D0E3C5080C8F074E1458CF8CCBC29599CC7E12DA6B3A2E32C83BC8A00EED720FA3AAB231E189DFB1D94D6743C3B64FF0E8C45E2D124C267042730C7DE81F1295979AEFD5FFC721F7CC5E4ECE468B53EF9F0EE3D724EDEFF0B9FBCAB8F14C60A74DC0B78F5290A421C816C785D8EDF342CBE9F25762CBBD5FA645A015B8285611A37E8F923261BFA084BE6F883695CB9CFD829DEE4C6F585B8B08EA0138D1278BC4D3C0FAD3C5CB65B8D3CD9FF0D5C8FDFBD1F85EB2D7A7237E9D40BFC61E144B0AE3E632F6D8D1FDD305B5EDC7C3FE4645751E0B367DEBEB2D687659044361B4CA025B947D106535EBAB955196F27936650E39B7581BAFFA6CD2495CD5B49CA06B4CD4A28584CBD1A0A795F976F678B3B0F4398BCD4B498469A0C4E755CCD84FE0706475599CF5157F32130ACBFF26EF829026F217AB80DFC55D4B42DC29F9DD837735BE24D429C602A76F9E0CE43EC79AE134C36BCC91802E503F6430FA38A1958FCC9716F3BB8F491EB8D702C76E0023EE9DA8D7C5C5AFB0F016C4288F4B75D14C7702A38FF41F1E304736B27116C564B8AFCF0F52DF73120F836F1576C0F9C8ED7685373FF6B70856C1A449784F51A8CF731B0BF0609BD24CE05A2F80BB50B40F678EFFADD014611E7DCB6711C5F8131636711C0956BD8E26347D5AEDDD285875C5FED970A87EA43415AF9A66A0AC93FD590A97CD426513F061B977413B520D58B9A51B48A9A93F5159581759334A7D40B9A12B4CA99518DE6F5A73334BEDB9FC2EEBFDF3FCC89D3ED0535352E6187C43F628223D8C69C4F88521C916A06BAEC1BBB701AD3E9634C5FFD6C4A39FD84BC646C565BAD867413187F35A4B0FBBF1A5231E1F593EB30AFA4C365B82006F84EF4EA7B76FB9A13249BFE0E551BE6D4CCA7D90374CBE53C8E03DB4D5781220C9A07B178F9C18733DA235AD968C4A8180C0C0CDD65471EBC81B199A251DD910BEC618A8D733B0B132F506C234756230CC8E9215871A22A04ABA263BC70FF947882A5E3887542EC1214C34A75099597854B6C37445EAB96849E1D8F3036F69287D87281434C18C3564D7461AE0E8631014A3EC2A4B469686ED52CAED910355EAB6ECEDB5CD86ADEA518D52436D9E23B6BEC32F7DF5EC5309B3536817136ABA48B00DAC0EE2E0C34BFAB743500F1E2B26F062ADC9834069ABB54931828AFB11D1828AF923767A0D915B5EBFC0BF7D57D334FFEA23CFDB1DEA8AE1DD826A78F3D33CDCCF7843E147AE04836CF8B156BC4CF5471390339F3FB599CBBBAA28930F025A67CC8A6F277957EA8D50C221A51136065682DA0F9276109485A503D842B62798DD2E55E440FD822EED6089BEFFD026CCD0664ECFAA7F11AA1FE03BA689C9D6E1FE5C84A6B908CBCD365A186A3300871F3E207DE4129BAB8ACAC982EBE701F6FB836B07C321A14D4E2B96A94540C66742D15A6D9AE259543D6C7251BA425C17DD268A918CCE85ACA6DB45D490AA7A0875B304845FC113ED2622B221DE56953B6CDAD2C672E7F31B734C975F31B14862ED9D492EDF237C632CBB45B7CBBEC9F80E66718961D2BF2D04A694B4E3488D0060BADC01A24BD72A3985E208A5688C579168E2F9129CF56CDF65FB0AC1F9FF22416E74041CDFECEF77655220777DACAEE488E720563F4994F9306D21516A0EE6EB0F447E4A14811BB5F045EE213BD8BA5EF9D7DC1ABF7CFDEC808734B905F72A1247D498E2EAFFC4E53232F8BD1A6A9F461B69F2A3D844EE185075A57B9CE2BD5A31441AA3A8A2E70B5B3A9D339333DA74BF414FBCF562BC2EBAC2D214DA90E243475C7149391EAA0625B6F49AB142085AC55637F69D5C0726B77643E89A88ECAB77447CC9389EA50F9AB9E18B57C1409ACD6D66376B894216E6AB8963EF3C2E505F193C235F590B29EFDC309596FD80A4FA3513545770E72BE4F1D5D6EED8EACC8FCA9432B9AB7C056C82CB67547552407D58115CDDDB1AB4C21F1D0DB635F437BDB1CE06C64218961DE8606E3754EB0719C955AE6451DA8F6BA27569E5B2181E5EFF7D29EB4F7F201F694C5A286D9930643BFFB70590BFCE6D3986AA1C7E4521178CFA32115438FD7CF6A5FD536A48BB94852722F2FE8C2457C9E5F8ADB4BE1A45B7246621A851AE1707F8929F6678C60B6FCC55B782E665B7941708388BBC631CDD26F4CB8C47F106AE9F6A7AECD8A63C753041574C56DFC9C4D9049479E50643FA248CE6B1950FB55814A9F0CAE89839FCFCCFFA5BD4ED3E813FB2B7D7D605CC75F88FB4B020DF751828DDFE43CDD716A619A2FC67B5AB9D45DABD73F3F645D0F8CBB0856CCA97128E8729B19E6EB997A4993751D20CDD6554E6F774129CB870AF46F7CF4FC8F3AE4F625428320356540A388392AA8AA9CC765A7CA90621EE55C0BDBD4F6B53B2BB7BF78AABA9D8193A1A8CD19663272FDCD5878A3A850575FB30D96B6B6C681479AD6D6F41BACBAD6661BD1B47536DBAC0AB1CAA6FBE150F4DCA103A0B8AB4E7150A47A6EAD521894B2BC6B8F412A6618B4D0E582851E70038A12B6B08C3796CF3FA2CF22A5EB8F86BD4BD37EF51CFD7D49CBAF12A6769B8D3F65027EC307D6BF54DEFD1E648A2A32DF769F5D3FB5ADE9E2EB7B9EA2DC2F877ECF8C2DCF87DC7DA6FCD4C6A60BBEEFB9B1F5CA87DF335BDBD5F9B9634BEB7C84EE3CBB5D4ED4D37C275345E8DBB2D7B3CF1970C35FB13853E6516645C7EA74C9A654EF168615899EA93E4F53642C2D1C89AF44D1CCB6DF58F303BF71B0394D335B4D767313EF7CFF6FE49DD334F3D6E40CEF22EF5E99B5ABAA8568D9C79AD209DF529E3D379296B28E369FB531E9E12DA5D58FA2146EF568BEDCBF9D2CFA515432E6D2E991352F7F8487B3B3F6ABB5707EC7EEA68260BF614BB0CD9D9A25CD355907C5E12D48549008119A1B4C910347EA7944DD35B22934B31873FAAB0969DC8E7DE95861E79ADC25344C280C19FB2B8F0B783127A0897F5A1AC0CB3CBF0BD31F001A630820A6CB62F377E487C4F59C52EE2B454C4803C1BC8B3CA2CBE692B2C8EEE6A544BA0D4847A05C7DA55374CFBE5F01587C4796E8096F231B98DF47BC41F64B1501D481B44F04AFF6F9858B3611F2E31CA3EA0F8F60C38EFFFCDDFF01A89B5422BC590000 , N'6.1.3-40302')
END
