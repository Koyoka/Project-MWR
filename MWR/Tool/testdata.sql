-- ������������
DELETE FROM `mwcar`;
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('��A00001','����');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('��A00002','����');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('��A00003','����');
INSERT INTO `mwcar`(`CarCode`,`Desc`)
VALUES('��A00004','����');

-- Ա����������
DELETE  FROM `mwemploy`;
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0001','��3-˾��',0,'D','zs3','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0002','��4-˾��',0,'D','zs4','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0003','��5-˾��',0,'D','zs5','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0004','��6-˾��',0,'D','zs6','1');

INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0005','��3-����',0,'I','ls3','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0006','��4-����',0,'I','ls4','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0007','��5-����',0,'I','ls5','1');
INSERT INTO `mwemploy`(`EmpyCode`,`EmpyName`,`UserGroupId`,`EmpyType`,`UserName`,`Password`)
VALUES('YG0008','��6-����',0,'I','ls6','1');

-- ����վ��������
DELETE FROM `mwworkstation`;
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('WS001','���ù���վ','D','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('WS002','��湤��վ','I','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS001','�ֻ��ն�1','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS002','�ֻ��ն�2','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS003','�ֻ��ն�3','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`, `AccessKey`, `SecretKey`)
VALUES('MWS004','�ֻ��ն�4','M','9e15f4f7d6fdc178eeab8caf79d863054bdfea78','ae46214f1ee0269f7eb5126895ff166f02ede4f1');

-- �����������
DELETE FROM `MWCrate`;
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX001', '����1', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX002', '����2', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX003', '����3', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX004', '����4', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX005', '����5', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX006', '����6', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX007', '����7', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX008', '����8', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX009', '����9', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX010', '����10', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX011', '����11', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX012', '����12', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX013', '����13', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX014', '����14', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX015', '����15', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX016', '����16', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX017', '����17', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX018', '����18', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX019', '����19', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX020', '����20', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX021', '����21', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX022', '����22', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX023', '����23', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX024', '����24', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX025', '����25', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX026', '����26', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX027', '����27', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX028', '����28', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX029', '����29', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX030', '����30', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX031', '����31', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX032', '����32', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX033', '����33', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX034', '����34', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX035', '����35', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX036', '����36', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX037', '����37', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX038', '����38', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX039', '����39', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX040', '����40', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX041', '����41', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX042', '����42', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX043', '����43', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX044', '����44', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX045', '����45', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX046', '����46', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX047', '����47', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX048', '����48', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX049', '����49', 'A');
INSERT INTO `MWRData`.`MWCrate` (`CrateCode`, `Desc`, `Status`) VALUES ('HX050', '����50', 'A');

-- ҽԺ��������
DELETE FROM `MWVendor`;
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY001', '����ҽԺ', '���ϵ�ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY002', '����ҽԺ', '���ϵ�ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY003', '����ҽԺ', '���ϵ�ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY004', '����ҽԺ', '���ϵ�ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY005', '����ҽԺ', '������ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY006', '�б�ҽԺ', '�б���ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY007', '����ҽԺ', '������ַ');
INSERT INTO `MWRData`.`MWVendor` (`VendorCode`, `Vendor`, `Address`) VALUES ('YY008', '�人ҽԺ', '�人��ַ');

-- ���ϻ�������
DELETE FROM `MWWasteCategory`;
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF001', 'A�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF002', 'B�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF003', 'C�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF004', 'D�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF005', 'E�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF006', 'F�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF007', 'G�ͷ���');
INSERT INTO `MWRData`.`MWWasteCategory` (`WasteCode`, `Waste`) VALUES ('YF008', 'H�ͷ���');



