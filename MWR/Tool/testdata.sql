-- 车辆基础数据
DELETE FROM `mwcar`;
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('鄂A00001','卡车');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('鄂A00002','卡车');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('鄂A00003','卡车');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('鄂A00004','卡车');

-- 员工基础数据
DELETE  FROM `mwemploy`;
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0001','张3-司机',0,'D','zs3','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0002','张4-司机',0,'D','zs4','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0003','张5-司机',0,'D','zs5','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0004','张6-司机',0,'D','zs6','1');

INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0005','李3-跟车',0,'I','ls3','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0006','李4-跟车',0,'I','ls4','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0007','李5-跟车',0,'I','ls5','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0008','李6-跟车',0,'I','ls6','1');

-- 工作站基础数据
DELETE FROM `mwworkstation`;
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('WS001','处置工作站','D','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('WS002','库存工作站','I','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS001','手机终端1','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS002','手机终端2','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS003','手机终端3','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS004','手机终端4','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');

-- 货箱基础数据
DELETE FROM `MWCrate`;
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX001', '货箱1', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX002', '货箱2', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX003', '货箱3', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX004', '货箱4', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX005', '货箱5', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX006', '货箱6', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX007', '货箱7', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX008', '货箱8', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX009', '货箱9', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX010', '货箱10', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX011', '货箱11', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX012', '货箱12', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX013', '货箱13', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX014', '货箱14', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX015', '货箱15', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX016', '货箱16', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX017', '货箱17', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX018', '货箱18', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX019', '货箱19', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX020', '货箱20', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX021', '货箱21', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX022', '货箱22', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX023', '货箱23', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX024', '货箱24', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX025', '货箱25', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX026', '货箱26', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX027', '货箱27', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX028', '货箱28', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX029', '货箱29', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX030', '货箱30', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX031', '货箱31', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX032', '货箱32', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX033', '货箱33', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX034', '货箱34', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX035', '货箱35', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX036', '货箱36', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX037', '货箱37', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX038', '货箱38', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX039', '货箱39', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX040', '货箱40', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX041', '货箱41', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX042', '货箱42', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX043', '货箱43', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX044', '货箱44', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX045', '货箱45', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX046', '货箱46', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX047', '货箱47', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX048', '货箱48', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX049', '货箱49', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX050', '货箱50', 'A');

-- 医院基础数据
DELETE FROM `MWVendor`;
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY001', '东南医院', '东南地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY002', '中南医院', '中南地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY003', '西南医院', '西南地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY004', '北南医院', '北南地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY005', '东北医院', '东北地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY006', '中北医院', '中北地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY007', '西北医院', '西北地址');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY008', '武汉医院', '武汉地址');

-- 废料基础数据
DELETE FROM `MWWasteCategory`;
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF001', 'A型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF002', 'B型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF003', 'C型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF004', 'D型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF005', 'E型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF006', 'F型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF007', 'G型废料');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF008', 'H型废料');



