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
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('WS001','���ù���վ','D');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('WS002','��湤��վ','I');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS001','�ֻ��ն�1','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS002','�ֻ��ն�2','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS003','�ֻ��ն�3','M');
INSERT INTO `mwworkstation`(`WSCode`,`Desc`,`WSType`)
VALUES('MWS004','�ֻ��ն�4','M');





