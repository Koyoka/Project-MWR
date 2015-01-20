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
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('WS001','处置工作站','D');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('WS002','库存工作站','I');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS001','手机终端1','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS002','手机终端2','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS003','手机终端3','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS004','手机终端4','M');





