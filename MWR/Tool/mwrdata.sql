/*
Navicat MySQL Data Transfer

Source Server         : 127.0.0.1
Source Server Version : 50621
Source Host           : 127.0.0.1:3306
Source Database       : mwrdata

Target Server Type    : MYSQL
Target Server Version : 50621
File Encoding         : 65001

Date: 2015-03-25 18:18:04
*/

SET FOREIGN_KEY_CHECKS=0;
-- ----------------------------
-- Table structure for `mwcar`
-- ----------------------------
DROP TABLE IF EXISTS `mwcar`;
CREATE TABLE `mwcar` (
  `CarCode` varchar(20) NOT NULL,
  `Desc` varchar(45) DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`CarCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='车辆基础数据';

-- ----------------------------
-- Records of mwcar
-- ----------------------------
INSERT INTO `mwcar` VALUES ('0', '1', 'A');
INSERT INTO `mwcar` VALUES ('00', '00', 'A');
INSERT INTO `mwcar` VALUES ('000', '000', 'A');
INSERT INTO `mwcar` VALUES ('鄂A00001', '卡车1', 'A');
INSERT INTO `mwcar` VALUES ('鄂A00002', '卡车', null);
INSERT INTO `mwcar` VALUES ('鄂A00003', '卡车', 'A');
INSERT INTO `mwcar` VALUES ('鄂A00004', '卡车', null);

-- ----------------------------
-- Table structure for `mwcardispatch`
-- ----------------------------
DROP TABLE IF EXISTS `mwcardispatch`;
CREATE TABLE `mwcardispatch` (
  `CarDisId` int(11) NOT NULL,
  `CarCode` varchar(20) DEFAULT NULL,
  `Driver` varchar(45) DEFAULT NULL COMMENT '司机姓名',
  `DriverCode` varchar(20) DEFAULT NULL COMMENT '司机编号',
  `Inspector` varchar(45) DEFAULT NULL COMMENT '跟车员姓名',
  `InspectorCode` varchar(20) DEFAULT NULL COMMENT '跟车员编号',
  `RecoMWSCode` varchar(20) DEFAULT NULL COMMENT '回收使用的手机终端',
  `OutDate` datetime DEFAULT NULL,
  `InDate` datetime DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL COMMENT '车辆派遣状态\n1.班次开始 S strat\n2.班次完成 E end',
  PRIMARY KEY (`CarDisId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='车辆班次信息记录';

-- ----------------------------
-- Records of mwcardispatch
-- ----------------------------
INSERT INTO `mwcardispatch` VALUES ('1', '鄂A00001', '张3-司机', 'YG0001', '李3-跟车', 'YG0005', 'MWS0001', '2015-03-02 14:29:42', '2015-03-02 15:30:31', 'E');

-- ----------------------------
-- Table structure for `mwcrate`
-- ----------------------------
DROP TABLE IF EXISTS `mwcrate`;
CREATE TABLE `mwcrate` (
  `CrateCode` varchar(20) NOT NULL,
  `Desc` varchar(45) DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL COMMENT '货箱状态\n1.使用中 A active\n2.作废 V void',
  PRIMARY KEY (`CrateCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='货箱基础数据';

-- ----------------------------
-- Records of mwcrate
-- ----------------------------
INSERT INTO `mwcrate` VALUES ('000', '额晚饭', 'A');
INSERT INTO `mwcrate` VALUES ('0000', '0000', '');
INSERT INTO `mwcrate` VALUES ('00000', '00000', '');
INSERT INTO `mwcrate` VALUES ('001', '0012', 'A');
INSERT INTO `mwcrate` VALUES ('002', '002', '');
INSERT INTO `mwcrate` VALUES ('01', '01', '');
INSERT INTO `mwcrate` VALUES ('11', '11', '');
INSERT INTO `mwcrate` VALUES ('HX001', '货箱1', 'A');
INSERT INTO `mwcrate` VALUES ('HX002', '货箱2', 'A');
INSERT INTO `mwcrate` VALUES ('HX003', '货箱3', 'A');
INSERT INTO `mwcrate` VALUES ('HX004', '货箱4', 'V');
INSERT INTO `mwcrate` VALUES ('HX005', '货箱5', 'A');
INSERT INTO `mwcrate` VALUES ('HX006', '货箱6', 'A');
INSERT INTO `mwcrate` VALUES ('HX007', '货箱7', 'A');
INSERT INTO `mwcrate` VALUES ('HX008', '货箱8', 'A');
INSERT INTO `mwcrate` VALUES ('HX009', '货箱9', 'A');
INSERT INTO `mwcrate` VALUES ('HX010', '货箱10', 'A');
INSERT INTO `mwcrate` VALUES ('HX011', '货箱11', 'A');
INSERT INTO `mwcrate` VALUES ('HX012', '货箱12', 'A');
INSERT INTO `mwcrate` VALUES ('HX013', '货箱13', 'A');
INSERT INTO `mwcrate` VALUES ('HX014', '货箱14', 'A');
INSERT INTO `mwcrate` VALUES ('HX015', '货箱15', 'A');
INSERT INTO `mwcrate` VALUES ('HX016', '货箱16', 'A');
INSERT INTO `mwcrate` VALUES ('HX017', '货箱17', 'A');
INSERT INTO `mwcrate` VALUES ('HX018', '货箱18', 'A');
INSERT INTO `mwcrate` VALUES ('HX019', '货箱19', 'A');
INSERT INTO `mwcrate` VALUES ('HX020', '货箱20', 'A');
INSERT INTO `mwcrate` VALUES ('HX021', '货箱21', 'A');
INSERT INTO `mwcrate` VALUES ('HX022', '货箱22', 'A');
INSERT INTO `mwcrate` VALUES ('HX023', '货箱23', 'A');
INSERT INTO `mwcrate` VALUES ('HX024', '货箱24', 'A');
INSERT INTO `mwcrate` VALUES ('HX025', '货箱25', 'A');
INSERT INTO `mwcrate` VALUES ('HX026', '货箱26', 'A');
INSERT INTO `mwcrate` VALUES ('HX027', '货箱27', 'A');
INSERT INTO `mwcrate` VALUES ('HX028', '货箱28', 'A');
INSERT INTO `mwcrate` VALUES ('HX029', '货箱29', 'A');
INSERT INTO `mwcrate` VALUES ('HX030', '货箱30', 'A');
INSERT INTO `mwcrate` VALUES ('HX031', '货箱31', 'A');
INSERT INTO `mwcrate` VALUES ('HX032', '货箱32', 'A');
INSERT INTO `mwcrate` VALUES ('HX033', '货箱33', 'A');
INSERT INTO `mwcrate` VALUES ('HX034', '货箱34', 'A');
INSERT INTO `mwcrate` VALUES ('HX035', '货箱35', 'A');
INSERT INTO `mwcrate` VALUES ('HX036', '货箱36', 'A');
INSERT INTO `mwcrate` VALUES ('HX037', '货箱37', 'A');
INSERT INTO `mwcrate` VALUES ('HX038', '货箱38', 'A');
INSERT INTO `mwcrate` VALUES ('HX039', '货箱39', 'A');
INSERT INTO `mwcrate` VALUES ('HX040', '货箱40', 'A');
INSERT INTO `mwcrate` VALUES ('HX041', '货箱41', 'A');
INSERT INTO `mwcrate` VALUES ('HX042', '货箱42', 'A');
INSERT INTO `mwcrate` VALUES ('HX043', '货箱43', 'A');
INSERT INTO `mwcrate` VALUES ('HX044', '货箱44', 'A');
INSERT INTO `mwcrate` VALUES ('HX045', '货箱45', 'A');
INSERT INTO `mwcrate` VALUES ('HX046', '货箱46', 'A');
INSERT INTO `mwcrate` VALUES ('HX047', '货箱47', 'A');
INSERT INTO `mwcrate` VALUES ('HX048', '货箱48', 'A');
INSERT INTO `mwcrate` VALUES ('HX049', '货箱49', 'A');
INSERT INTO `mwcrate` VALUES ('HX050', '货箱50', 'A');

-- ----------------------------
-- Table structure for `mwdepot`
-- ----------------------------
DROP TABLE IF EXISTS `mwdepot`;
CREATE TABLE `mwdepot` (
  `DeptCode` varchar(20) NOT NULL,
  `Total` int(11) DEFAULT NULL,
  `Desc` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`DeptCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='库房基础数据';

-- ----------------------------
-- Records of mwdepot
-- ----------------------------
INSERT INTO `mwdepot` VALUES ('001', '0', '001d1');
INSERT INTO `mwdepot` VALUES ('a', '0', 'a11');
INSERT INTO `mwdepot` VALUES ('CK001', '100', '1号仓库');
INSERT INTO `mwdepot` VALUES ('CK002', '100', '2号仓库');
INSERT INTO `mwdepot` VALUES ('CK003', '100', '3号仓库');
INSERT INTO `mwdepot` VALUES ('CK004', '100', '4号仓库');
INSERT INTO `mwdepot` VALUES ('CK005', '100', '5号仓库');

-- ----------------------------
-- Table structure for `mwdestroydetail`
-- ----------------------------
DROP TABLE IF EXISTS `mwdestroydetail`;
CREATE TABLE `mwdestroydetail` (
  `DestroyDtlId` int(11) NOT NULL,
  `CrateCode` varchar(20) DEFAULT NULL,
  `DestHeaderId` int(11) DEFAULT NULL,
  `DestNum` varchar(20) DEFAULT NULL,
  `DepotCode` varchar(20) DEFAULT NULL COMMENT '仓库编号',
  `Vendor` varchar(45) DEFAULT NULL,
  `VendorCode` varchar(20) DEFAULT NULL,
  `Waste` varchar(45) DEFAULT NULL,
  `WasteCode` varchar(20) DEFAULT NULL,
  `PostWeight` float DEFAULT NULL,
  `DestWeight` float DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  `PostHeaderId` int(11) DEFAULT NULL,
  `InvRecordId` int(11) DEFAULT NULL COMMENT '关联库存ID',
  `InvAuthId` int(11) DEFAULT NULL,
  PRIMARY KEY (`DestroyDtlId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwdestroydetail
-- ----------------------------

-- ----------------------------
-- Table structure for `mwemploy`
-- ----------------------------
DROP TABLE IF EXISTS `mwemploy`;
CREATE TABLE `mwemploy` (
  `EmpyCode` varchar(20) NOT NULL,
  `EmpyName` varchar(45) DEFAULT NULL,
  `FuncGroupId` int(11) DEFAULT NULL,
  `EmpyType` varchar(2) DEFAULT NULL COMMENT '员工类型\n1.司机 D\n2.跟车员 I\n3.工作站操作员 W',
  `UserName` varchar(45) DEFAULT NULL,
  `Password` varchar(45) DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`EmpyCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='员工表-记录员工信息，以及员工用户组';

-- ----------------------------
-- Records of mwemploy
-- ----------------------------
INSERT INTO `mwemploy` VALUES ('001', '任正', '1', 'D', '', '[VylDbEuH{euZG_Yu\\qQ{lXOzosZWQy`QYmEZgNMx[|', 'A');
INSERT INTO `mwemploy` VALUES ('0010', '001', '-1', 'D', '', 'PygM_tRvReJ}|vHI[@aHK}ZsDpk@~NQtX{DDPAl@IY\\', 'A');
INSERT INTO `mwemploy` VALUES ('11', '1', '-1', 'I', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', 'A');
INSERT INTO `mwemploy` VALUES ('administrator', 'administrator', '-1', 'S', 'administrator', 'yZR^zcwkvCjkN{DfoKTVUYP`p~H]urU^Fby]jWoPRsP', 'A');
INSERT INTO `mwemploy` VALUES ('YG0001', '张1', '1', 'D', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', 'A');
INSERT INTO `mwemploy` VALUES ('YG0002', '张2', '-3', 'D', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0003', '张3', '-4', 'D', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0004', '张4', '-1', 'D', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0005', '张5', '-2', 'I', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0006', '张6', '-3', 'I', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0007', '张7', '-4', 'I', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0008', '张8', '-1', 'I', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0009', '张9', '0', 'S', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0010', '张10', '0', 'S', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0011', '张11', '0', 'S', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0012', '张12', '0', 'S', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', '');
INSERT INTO `mwemploy` VALUES ('YG0013', '张1322', '-1', 'S', '', 'QO}nyeVntm~csV[{O]qyotukIw_Lv~xmWt@@XKUdT', 'A');

-- ----------------------------
-- Table structure for `mwfunction`
-- ----------------------------
DROP TABLE IF EXISTS `mwfunction`;
CREATE TABLE `mwfunction` (
  `FuncTag` varchar(45) NOT NULL,
  `FuncName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FuncTag`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwfunction
-- ----------------------------
INSERT INTO `mwfunction` VALUES ('BackOffice-CarDispatch', '管理中心-车辆调度管理');
INSERT INTO `mwfunction` VALUES ('BackOffice-CarLocus', '管理中心-车辆历史轨迹');
INSERT INTO `mwfunction` VALUES ('BackOffice-CarRound', '管理中心-地理围栏设置');
INSERT INTO `mwfunction` VALUES ('BackOffice-CarTrack', '管理中心-车辆行驶跟踪');
INSERT INTO `mwfunction` VALUES ('BackOffice-FuncGroupEdit', '管理中心-权限组管理');
INSERT INTO `mwfunction` VALUES ('BackOffice-InvAuthorize', '管理中心-查看审核列表');
INSERT INTO `mwfunction` VALUES ('BackOffice-InvAuthorizeDetail', '管理中心-问题货箱审核');
INSERT INTO `mwfunction` VALUES ('BackOffice-Main', '管理中心-登录权限');
INSERT INTO `mwfunction` VALUES ('BackOffice-UserPermit', '管理中心-用户权限管理');
INSERT INTO `mwfunction` VALUES ('BackOffice-WSManage', '管理中心-工作站管理');
INSERT INTO `mwfunction` VALUES ('Destroy-Main', '处置工作站-使用权限');
INSERT INTO `mwfunction` VALUES ('Inventory-Main', '库存工作站-使用权限');

-- ----------------------------
-- Table structure for `mwfunctiongroup`
-- ----------------------------
DROP TABLE IF EXISTS `mwfunctiongroup`;
CREATE TABLE `mwfunctiongroup` (
  `FuncGroupId` int(11) NOT NULL,
  `FuncGroupName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FuncGroupId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwfunctiongroup
-- ----------------------------
INSERT INTO `mwfunctiongroup` VALUES ('1', 'web开发测试');

-- ----------------------------
-- Table structure for `mwfunctiongroupdetail`
-- ----------------------------
DROP TABLE IF EXISTS `mwfunctiongroupdetail`;
CREATE TABLE `mwfunctiongroupdetail` (
  `FuncGroupDtlId` int(11) NOT NULL,
  `FuncGroupId` int(11) DEFAULT NULL,
  `FuncTag` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`FuncGroupDtlId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwfunctiongroupdetail
-- ----------------------------
INSERT INTO `mwfunctiongroupdetail` VALUES ('1', '1', 'BackOffice-UserPermit');
INSERT INTO `mwfunctiongroupdetail` VALUES ('2', '1', 'BackOffice-Main');
INSERT INTO `mwfunctiongroupdetail` VALUES ('3', '1', 'BackOffice-CarDispatch');
INSERT INTO `mwfunctiongroupdetail` VALUES ('5', '1', 'BackOffice-InvAuthorize');
INSERT INTO `mwfunctiongroupdetail` VALUES ('6', '1', 'BackOffice-InvAuthorizeDetail');
INSERT INTO `mwfunctiongroupdetail` VALUES ('7', '1', 'BackOffice-WSManage');

-- ----------------------------
-- Table structure for `mwinvauthorize`
-- ----------------------------
DROP TABLE IF EXISTS `mwinvauthorize`;
CREATE TABLE `mwinvauthorize` (
  `InvAuthId` int(11) NOT NULL,
  `TxnNum` varchar(20) DEFAULT NULL COMMENT '交易编号',
  `TxnDetailId` int(11) DEFAULT NULL COMMENT '当前审核交易货箱的ID',
  `EmpyCode` varchar(20) DEFAULT NULL COMMENT '提交的工作人员编号',
  `EmpyName` varchar(45) DEFAULT NULL COMMENT '提交审核工作员姓名',
  `WSCode` varchar(20) DEFAULT NULL COMMENT '提交的工作站编号',
  `AuthEmpyCode` varchar(20) DEFAULT NULL COMMENT '审核员编号',
  `AuthEmpyName` varchar(45) DEFAULT NULL COMMENT '审核员姓名',
  `Remark` varchar(45) DEFAULT NULL COMMENT '审核备注',
  `SubWeight` decimal(10,2) DEFAULT NULL COMMENT '提交的重量',
  `TxnWeight` decimal(10,2) DEFAULT NULL COMMENT '交易中实际的重量',
  `DiffWeight` decimal(10,2) DEFAULT NULL COMMENT '重量差值',
  `EntryDate` datetime DEFAULT NULL COMMENT '审核提交的时间',
  `CompDate` datetime DEFAULT NULL COMMENT '审核完成的时间',
  `Status` varchar(2) DEFAULT NULL COMMENT '审核的状态\n1.提交等待审核中\n2.审核完成',
  PRIMARY KEY (`InvAuthId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='废品审核授权表-对有缺陷的废品进行人工审核授权记录，并记录附件\n审核时针对交易的审核';

-- ----------------------------
-- Records of mwinvauthorize
-- ----------------------------
INSERT INTO `mwinvauthorize` VALUES ('1', '0000000001', '2', 'YG0008', '李6-跟车', 'WS001', 'YG0008', '李6-跟车', 'jjkjjjjj', '1.82', '0.40', '1.42', '2015-03-02 14:47:19', '2015-03-02 15:09:34', 'C');

-- ----------------------------
-- Table structure for `mwinvauthorizeattach`
-- ----------------------------
DROP TABLE IF EXISTS `mwinvauthorizeattach`;
CREATE TABLE `mwinvauthorizeattach` (
  `InvAttachId` int(11) NOT NULL,
  `InvAuthId` int(11) DEFAULT NULL,
  `Path` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`InvAttachId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwinvauthorizeattach
-- ----------------------------
INSERT INTO `mwinvauthorizeattach` VALUES ('1', '1', 'UploadFile//0000000001//HX016//0000000001_HX016_2015030215092300_1212.sql');
INSERT INTO `mwinvauthorizeattach` VALUES ('2', '1', 'UploadFile//0000000001//HX016//0000000001_HX016_2015030215092300_dd407fc473434aa0b2cc5c89e4ded622_b.jpg');

-- ----------------------------
-- Table structure for `mwinventory`
-- ----------------------------
DROP TABLE IF EXISTS `mwinventory`;
CREATE TABLE `mwinventory` (
  `InvRecordId` int(11) NOT NULL,
  `CrateCode` varchar(20) DEFAULT NULL COMMENT '货箱编号',
  `DepotCode` varchar(20) DEFAULT NULL COMMENT '仓库编号',
  `Vendor` varchar(45) DEFAULT NULL COMMENT '供货商（医院）',
  `VendorCode` varchar(20) DEFAULT NULL COMMENT '供货商(医院)编号',
  `Waste` varchar(45) DEFAULT NULL COMMENT '废品名称',
  `WasteCode` varchar(20) DEFAULT NULL COMMENT '废品编号',
  `RecoWeight` decimal(10,2) DEFAULT NULL COMMENT '回收重量',
  `InvWeight` decimal(10,2) DEFAULT NULL COMMENT '库存重量',
  `PostWeight` decimal(10,2) DEFAULT NULL COMMENT '出库重量',
  `DestWeight` decimal(10,2) DEFAULT NULL COMMENT '销毁重量',
  `EntryDate` datetime DEFAULT NULL COMMENT '数据记录时间',
  `Status` varchar(3) DEFAULT NULL COMMENT '当前库存状态\n1.已入库 RED\n2.已出库PED\n3.已销毁DED\n4.入库中RIN\n5.出库中PIN\n6.销毁中DIN',
  `DailyClose` bit(1) DEFAULT NULL COMMENT '是否已经日结盘点',
  PRIMARY KEY (`InvRecordId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='库存表-记录库存信息，库存来源等';

-- ----------------------------
-- Records of mwinventory
-- ----------------------------
INSERT INTO `mwinventory` VALUES ('1', 'HX020', 'CK001', '西北医院', 'YY007', 'E型废料', 'YF005', '1.82', '1.10', '1.10', '1.10', '2015-03-02 14:45:33', 'DED', '\0');
INSERT INTO `mwinventory` VALUES ('2', 'HX016', 'CK001', '东南医院', 'YY001', 'A型废料', 'YF001', '1.82', '0.40', '1.10', '1.11', '2015-03-02 15:11:39', 'DED', '\0');

-- ----------------------------
-- Table structure for `mwinventorytrack`
-- ----------------------------
DROP TABLE IF EXISTS `mwinventorytrack`;
CREATE TABLE `mwinventorytrack` (
  `InvTrackRecordId` int(11) NOT NULL,
  `InvRecordId` int(11) DEFAULT NULL COMMENT '库存变更关联的库存ID',
  `TxnNum` varchar(20) DEFAULT NULL COMMENT '库存变更执行的交易流水号',
  `TxnType` varchar(2) DEFAULT NULL COMMENT '库存变更交易的类型\n1.回收入库 R\n2.出库 P\n3.销毁 D',
  `TxnDetailId` int(11) DEFAULT NULL COMMENT '库存变更关联的交易明细',
  `CrateCode` varchar(20) DEFAULT NULL COMMENT '变更的货箱编号',
  `DepotCode` varchar(20) DEFAULT NULL COMMENT '变更货箱的仓库编号',
  `Vendor` varchar(45) DEFAULT NULL COMMENT '供货商（医院）编号',
  `VendorCode` varchar(20) DEFAULT NULL COMMENT '供货商（医院）',
  `Waste` varchar(45) DEFAULT NULL COMMENT '废品名称',
  `WasteCode` varchar(20) DEFAULT NULL COMMENT '废品编号',
  `SubWeight` decimal(10,2) DEFAULT NULL COMMENT '库存变更的提交重量',
  `TxnWeight` decimal(10,2) DEFAULT NULL COMMENT '库存变更的成交重量',
  `WSCode` varchar(20) DEFAULT NULL COMMENT '库存操作工作站编号',
  `EmpyName` varchar(45) DEFAULT NULL COMMENT '库存操作员姓名',
  `EmpyCode` varchar(20) DEFAULT NULL COMMENT '库存操作员工编号',
  `EntryDate` datetime DEFAULT NULL COMMENT '库存变更的提交时间',
  `Status` varchar(2) DEFAULT NULL COMMENT '库存变更的操作状态\n1.Normal 该跟踪数据正常\n2.Void 该跟踪数据无效',
  `InvAuthId` int(11) DEFAULT NULL COMMENT '变更完成包含的审核信息ID',
  PRIMARY KEY (`InvTrackRecordId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='库存跟踪表-记录每次库存交易操作信息，（现在是两个工作站）\n库存变化的记录';

-- ----------------------------
-- Records of mwinventorytrack
-- ----------------------------
INSERT INTO `mwinventorytrack` VALUES ('1', '1', '0000000001', 'R', '1', 'HX020', 'CK001', '西北医院', 'YY007', 'E型废料', 'YF005', '1.82', '1.10', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 14:45:33', 'N', '0');
INSERT INTO `mwinventorytrack` VALUES ('2', '2', '0000000001', 'R', '2', 'HX016', 'CK001', '东南医院', 'YY001', 'A型废料', 'YF001', '1.82', '0.40', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 15:11:39', 'N', '1');
INSERT INTO `mwinventorytrack` VALUES ('3', '1', '0000000002', 'P', '3', 'HX020', 'CK001', '西北医院', 'YY007', 'E型废料', 'YF005', '1.10', '1.10', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 15:16:10', 'N', '0');
INSERT INTO `mwinventorytrack` VALUES ('4', '2', '0000000003', 'P', '4', 'HX016', 'CK001', '东南医院', 'YY001', 'A型废料', 'YF001', '0.40', '1.10', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 15:17:36', 'N', '0');
INSERT INTO `mwinventorytrack` VALUES ('5', '1', '0000000004', 'D', '5', 'HX020', 'CK001', '西北医院', 'YY007', 'E型废料', 'YF005', '1.10', '1.10', 'WS002', '李6-跟车', 'YG0008', '2015-03-02 15:20:12', 'N', '0');
INSERT INTO `mwinventorytrack` VALUES ('6', '2', '0000000004', 'D', '6', 'HX016', 'CK001', '东南医院', 'YY001', 'A型废料', 'YF001', '1.10', '1.11', 'WS002', '李6-跟车', 'YG0008', '2015-03-02 15:20:28', 'N', '0');

-- ----------------------------
-- Table structure for `mwpostdetail`
-- ----------------------------
DROP TABLE IF EXISTS `mwpostdetail`;
CREATE TABLE `mwpostdetail` (
  `PostDtlId` int(11) NOT NULL,
  `PostHeaderId` int(11) DEFAULT NULL,
  `CrateCode` varchar(20) DEFAULT NULL,
  `PostNum` varchar(20) DEFAULT NULL,
  `DepotCode` varchar(20) DEFAULT NULL COMMENT '仓库编号',
  `Vendor` varchar(45) DEFAULT NULL,
  `VendorCode` varchar(20) DEFAULT NULL,
  `Waste` varchar(45) DEFAULT NULL,
  `WasteCode` varchar(20) DEFAULT NULL,
  `InvWeight` float DEFAULT NULL,
  `PostWeight` float DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  `InvRecordId` int(11) DEFAULT NULL COMMENT '关联库存ID',
  `InvAuthId` int(11) DEFAULT NULL,
  PRIMARY KEY (`PostDtlId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='出库交易详情表';

-- ----------------------------
-- Records of mwpostdetail
-- ----------------------------

-- ----------------------------
-- Table structure for `mwrecoverdetail`
-- ----------------------------
DROP TABLE IF EXISTS `mwrecoverdetail`;
CREATE TABLE `mwrecoverdetail` (
  `RecoDtlId` int(11) NOT NULL,
  `RecoHeaderId` int(11) DEFAULT NULL,
  `CrateCode` varchar(20) DEFAULT NULL,
  `RecoNum` varchar(20) DEFAULT NULL,
  `Vendor` varchar(45) DEFAULT NULL,
  `VendorCode` varchar(20) DEFAULT NULL,
  `Waste` varchar(45) DEFAULT NULL,
  `WasteCode` varchar(20) DEFAULT NULL,
  `RecoWeight` float DEFAULT NULL,
  `RecoDate` datetime DEFAULT NULL,
  `InvAuthId` int(11) DEFAULT NULL,
  `Status` varchar(2) DEFAULT NULL,
  PRIMARY KEY (`RecoDtlId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='回收计划详情表-记录回收计划中包含的废品详情明细';

-- ----------------------------
-- Records of mwrecoverdetail
-- ----------------------------

-- ----------------------------
-- Table structure for `mwresidueinventory`
-- ----------------------------
DROP TABLE IF EXISTS `mwresidueinventory`;
CREATE TABLE `mwresidueinventory` (
  `ResdInvId` int(11) NOT NULL,
  `InvWeight` decimal(10,2) DEFAULT NULL,
  `EntryDate` datetime DEFAULT NULL,
  `HandlingDate` datetime DEFAULT NULL COMMENT '处理时间',
  `RecoWSCode` varchar(20) DEFAULT NULL,
  `RecoEmpyCode` varchar(20) DEFAULT NULL,
  `HandlingType` varchar(2) DEFAULT NULL COMMENT '处理方式\n1.埋\n2.烧',
  PRIMARY KEY (`ResdInvId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='残渣库存记录-记录残渣库存信息';

-- ----------------------------
-- Records of mwresidueinventory
-- ----------------------------

-- ----------------------------
-- Table structure for `mwtxndestroyheader`
-- ----------------------------
DROP TABLE IF EXISTS `mwtxndestroyheader`;
CREATE TABLE `mwtxndestroyheader` (
  `DestHeaderId` int(11) NOT NULL,
  `TxnNum` varchar(20) DEFAULT NULL COMMENT '销毁交易的流水号',
  `DestType` varchar(2) DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL COMMENT '交易开始的时间',
  `EndDate` datetime DEFAULT NULL COMMENT '交易结束的时间',
  `DestWSCode` varchar(20) DEFAULT NULL,
  `DestEmpyName` varchar(45) DEFAULT NULL,
  `DestEmpyCode` varchar(20) DEFAULT NULL,
  `TotalCrateQty` int(11) DEFAULT NULL COMMENT '销毁的箱子总数量',
  `TotalSubWeight` decimal(10,2) DEFAULT NULL COMMENT '销毁提交的总重量',
  `TotalTxnWeight` decimal(10,2) DEFAULT NULL COMMENT '交易完成的实际总重量',
  `Status` varchar(2) DEFAULT NULL COMMENT '销毁交易的状态\n1.处理中\n2.完成\n3.审核中',
  PRIMARY KEY (`DestHeaderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwtxndestroyheader
-- ----------------------------
INSERT INTO `mwtxndestroyheader` VALUES ('1', '0000000004', 'PD', '2015-03-02 15:20:12', '2015-03-02 15:20:50', 'WS002', '李6-跟车', 'YG0008', '2', '2.20', '2.21', 'C');

-- ----------------------------
-- Table structure for `mwtxndetail`
-- ----------------------------
DROP TABLE IF EXISTS `mwtxndetail`;
CREATE TABLE `mwtxndetail` (
  `TxnDetailId` int(11) NOT NULL,
  `TxnType` varchar(2) DEFAULT NULL COMMENT '当前交易明细产生的交易类型\n1.回收入库 R\n2.出库 P\n3.销毁 D\n//4.终端提交 S',
  `TxnNum` varchar(20) DEFAULT NULL COMMENT '库存交易流水号',
  `WSCode` varchar(20) DEFAULT NULL COMMENT '操作工作站',
  `EmpyName` varchar(45) DEFAULT NULL,
  `EmpyCode` varchar(20) DEFAULT NULL COMMENT '操作员',
  `CrateCode` varchar(20) DEFAULT NULL,
  `Vendor` varchar(45) DEFAULT NULL COMMENT '供货商（医院）',
  `VendorCode` varchar(20) DEFAULT NULL,
  `Waste` varchar(45) DEFAULT NULL COMMENT '医疗废品名称',
  `WasteCode` varchar(20) DEFAULT NULL,
  `SubWeight` decimal(10,2) DEFAULT NULL COMMENT '当前交易提交重量',
  `TxnWeight` decimal(10,2) DEFAULT NULL COMMENT '交易成交重量（实际重量）',
  `EntryDate` datetime DEFAULT NULL COMMENT '当前货箱交易添加时间',
  `InvRecordId` int(11) DEFAULT NULL COMMENT '交易关联的库存ID',
  `InvAuthId` int(11) DEFAULT NULL COMMENT '审核交易的ID',
  `Status` varchar(2) DEFAULT NULL COMMENT '当前交易的货箱状态\n1.交易完成 C complete\n2.交易货箱审核中 A authorize\n3.交易货箱审核完成，等待确认 W wait',
  PRIMARY KEY (`TxnDetailId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwtxndetail
-- ----------------------------
INSERT INTO `mwtxndetail` VALUES ('1', 'R', '0000000001', 'WS001', '李6-跟车', 'YG0008', 'HX020', '西北医院', 'YY007', 'E型废料', 'YF005', '1.82', '1.10', '2015-03-02 14:45:33', '1', '0', 'C');
INSERT INTO `mwtxndetail` VALUES ('2', 'R', '0000000001', 'WS001', '李6-跟车', 'YG0008', 'HX016', '东南医院', 'YY001', 'A型废料', 'YF001', '1.82', '0.40', '2015-03-02 15:11:39', '2', '1', 'C');
INSERT INTO `mwtxndetail` VALUES ('3', 'P', '0000000002', 'WS001', '李6-跟车', 'YG0008', 'HX020', '西北医院', 'YY007', 'E型废料', 'YF005', '1.10', '1.10', '2015-03-02 15:16:10', '1', '0', 'C');
INSERT INTO `mwtxndetail` VALUES ('4', 'P', '0000000003', 'WS001', '李6-跟车', 'YG0008', 'HX016', '东南医院', 'YY001', 'A型废料', 'YF001', '0.40', '1.10', '2015-03-02 15:17:36', '2', '0', 'C');
INSERT INTO `mwtxndetail` VALUES ('5', 'D', '0000000004', 'WS002', '李6-跟车', 'YG0008', 'HX020', '西北医院', 'YY007', 'E型废料', 'YF005', '1.10', '1.10', '2015-03-02 15:20:12', '1', '0', 'C');
INSERT INTO `mwtxndetail` VALUES ('6', 'D', '0000000004', 'WS002', '李6-跟车', 'YG0008', 'HX016', '东南医院', 'YY001', 'A型废料', 'YF001', '1.10', '1.11', '2015-03-02 15:20:28', '2', '0', 'C');

-- ----------------------------
-- Table structure for `mwtxnlog`
-- ----------------------------
DROP TABLE IF EXISTS `mwtxnlog`;
CREATE TABLE `mwtxnlog` (
  `TxnLogId` int(11) NOT NULL,
  `TxnNum` varchar(20) DEFAULT NULL,
  `TxnDetailId` int(11) DEFAULT NULL COMMENT '交易明细ID',
  `WSCode` varchar(20) DEFAULT NULL,
  `EmpyName` varchar(45) DEFAULT NULL,
  `EmpyCode` varchar(20) DEFAULT NULL,
  `OptType` varchar(2) DEFAULT NULL COMMENT '操作类型\n1.提交入库 SI  submit inventory\n2.提交审核 SA submit authorize\n3.确认审核并入库 AI authorize inventory',
  `OptDate` datetime DEFAULT NULL COMMENT '执行操作的时间',
  `TxnLogType` varchar(2) DEFAULT NULL COMMENT '库存日志的类型 -废品出库，废品入库，残渣出库，残渣入库\n1.回收入库 R\n2.出库 P\n3.销毁 D',
  `InvRecordId` int(11) DEFAULT NULL COMMENT '如果有库存 交易日志关联的库存\n',
  PRIMARY KEY (`TxnLogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='库存处理交易日志-出入库存中操作的wscode empycode为最终库存操作者，本表中记录某个库存操作的变化的日志\n包括废品出库，废品入库，残渣出库，残渣入库';

-- ----------------------------
-- Records of mwtxnlog
-- ----------------------------
INSERT INTO `mwtxnlog` VALUES ('1', '0000000001', '1', 'MWS0001', '李3-跟车', 'YG0005', 'SR', '2015-03-02 14:43:01', 'R', '0');
INSERT INTO `mwtxnlog` VALUES ('2', '0000000001', '2', 'MWS0001', '李3-跟车', 'YG0005', 'SR', '2015-03-02 14:43:01', 'R', '0');
INSERT INTO `mwtxnlog` VALUES ('3', '0000000001', '1', 'WS001', '李6-跟车', 'YG0008', 'SC', '2015-03-02 14:45:33', 'R', '1');
INSERT INTO `mwtxnlog` VALUES ('4', '0000000001', '2', 'WS001', '李6-跟车', 'YG0008', 'SA', '2015-03-02 14:47:19', 'R', '0');
INSERT INTO `mwtxnlog` VALUES ('5', '0000000001', '2', 'WS001', '李6-跟车', 'YG0008', 'AC', '2015-03-02 15:11:39', 'R', '2');
INSERT INTO `mwtxnlog` VALUES ('6', '0000000002', '3', 'WS001', '李6-跟车', 'YG0008', 'SC', '2015-03-02 15:16:10', 'P', '1');
INSERT INTO `mwtxnlog` VALUES ('7', '0000000003', '4', 'WS001', '李6-跟车', 'YG0008', 'SC', '2015-03-02 15:17:36', 'P', '2');
INSERT INTO `mwtxnlog` VALUES ('8', '0000000004', '5', 'WS002', '李6-跟车', 'YG0008', 'SC', '2015-03-02 15:20:12', 'D', '1');
INSERT INTO `mwtxnlog` VALUES ('9', '0000000004', '6', 'WS002', '李6-跟车', 'YG0008', 'SC', '2015-03-02 15:20:28', 'D', '2');

-- ----------------------------
-- Table structure for `mwtxnpostheader`
-- ----------------------------
DROP TABLE IF EXISTS `mwtxnpostheader`;
CREATE TABLE `mwtxnpostheader` (
  `PostHeaderId` int(11) NOT NULL,
  `TxnNum` varchar(20) DEFAULT NULL,
  `PostWSCode` varchar(20) DEFAULT NULL COMMENT '库存操作工作站编号',
  `PostEmpyName` varchar(45) DEFAULT NULL,
  `PostEmpyCode` varchar(20) DEFAULT NULL COMMENT '库存操作员工编号',
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `PostType` varchar(2) DEFAULT NULL COMMENT '出库类型\n1.正常-称重出库\n2.特殊-直接出库\n3.自动-由处理工作站发起自动生成出库交易信息',
  `TotalCrateQty` int(11) DEFAULT NULL COMMENT '交易中箱子的总重量',
  `TotalSubWeight` decimal(10,2) DEFAULT NULL COMMENT '出库提交的总重量',
  `TotalTxnWeight` decimal(10,2) DEFAULT NULL COMMENT '交易完成的实际总重量',
  `Status` varchar(2) DEFAULT NULL COMMENT '出库交易的状态\n1.处理中\n2.完成\n3.审核中',
  PRIMARY KEY (`PostHeaderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='出库交易信息表';

-- ----------------------------
-- Records of mwtxnpostheader
-- ----------------------------
INSERT INTO `mwtxnpostheader` VALUES ('1', '0000000002', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 15:16:10', '2015-03-02 15:16:44', 'N', '1', '1.10', '1.10', 'C');
INSERT INTO `mwtxnpostheader` VALUES ('2', '0000000003', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 15:17:36', '2015-03-02 15:18:53', 'N', '1', '0.40', '1.10', 'C');

-- ----------------------------
-- Table structure for `mwtxnrecoverheader`
-- ----------------------------
DROP TABLE IF EXISTS `mwtxnrecoverheader`;
CREATE TABLE `mwtxnrecoverheader` (
  `RecoHeaderId` int(11) NOT NULL,
  `TxnNum` varchar(20) DEFAULT NULL COMMENT '交易流水号',
  `CarCode` varchar(20) DEFAULT NULL COMMENT '车辆编号',
  `Driver` varchar(45) DEFAULT NULL COMMENT '司机姓名',
  `DriverCode` varchar(20) DEFAULT NULL COMMENT '司机编号',
  `Inspector` varchar(45) DEFAULT NULL COMMENT '跟车员姓名',
  `InspectorCode` varchar(20) DEFAULT NULL COMMENT '跟车员编号',
  `RecoMWSCode` varchar(20) DEFAULT NULL COMMENT '回收使用的手机终端',
  `RecoWSCode` varchar(20) DEFAULT NULL COMMENT '回收交易处理的回收站',
  `RecoEmpyName` varchar(45) DEFAULT NULL COMMENT '回收交易处理员工姓名',
  `RecoEmpyCode` varchar(20) DEFAULT NULL COMMENT '回收交易处理的员工',
  `StartDate` datetime DEFAULT NULL COMMENT '开始时间',
  `EndDate` datetime DEFAULT NULL COMMENT '结束时间',
  `OperateType` varchar(2) DEFAULT NULL COMMENT '处理类型-\n1.回收入库  I\n2.直接处置  D',
  `TotalCrateQty` int(11) DEFAULT NULL COMMENT '交易中箱子的总重量',
  `TotalSubWeight` decimal(10,2) DEFAULT NULL COMMENT '回收提交的总重量',
  `TotalTxnWeight` decimal(10,2) DEFAULT NULL COMMENT '交易完成的实际总重量',
  `CarDisId` int(11) DEFAULT NULL COMMENT '回收交易的车辆考勤记录',
  `Status` varchar(2) DEFAULT NULL COMMENT '当前交易状态\n1.处理中 P process\n2.完成 C complete\n3.审核中 A authorize',
  PRIMARY KEY (`RecoHeaderId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='回收计划信息表-记录提交的回收计划 \r\n回收入库交易表';

-- ----------------------------
-- Records of mwtxnrecoverheader
-- ----------------------------
INSERT INTO `mwtxnrecoverheader` VALUES ('1', '0000000001', '鄂A00001', '张3-司机', 'YG0001', '李3-跟车', 'YG0005', 'MWS0001', 'WS001', '李6-跟车', 'YG0008', '2015-03-02 14:43:21', '2015-03-02 15:11:39', 'I', '2', '3.64', '0.00', '1', 'C');

-- ----------------------------
-- Table structure for `mwusergroup`
-- ----------------------------
DROP TABLE IF EXISTS `mwusergroup`;
CREATE TABLE `mwusergroup` (
  `UserGroupId` int(11) NOT NULL,
  `GroupName` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`UserGroupId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of mwusergroup
-- ----------------------------
INSERT INTO `mwusergroup` VALUES ('-4', '工作站-处置');
INSERT INTO `mwusergroup` VALUES ('-3', '工作站-库存');
INSERT INTO `mwusergroup` VALUES ('-2', '管理中心');
INSERT INTO `mwusergroup` VALUES ('-1', 'Administrator');

-- ----------------------------
-- Table structure for `mwuserpermission`
-- ----------------------------
DROP TABLE IF EXISTS `mwuserpermission`;
CREATE TABLE `mwuserpermission` (
  `id` int(11) NOT NULL,
  `UserGroupId` int(11) DEFAULT NULL,
  `FuncGroupId` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='用户权限表-记录用户组使用的功能';

-- ----------------------------
-- Records of mwuserpermission
-- ----------------------------
INSERT INTO `mwuserpermission` VALUES ('-1', '-1', '-1');

-- ----------------------------
-- Table structure for `mwvendor`
-- ----------------------------
DROP TABLE IF EXISTS `mwvendor`;
CREATE TABLE `mwvendor` (
  `VendorCode` varchar(20) NOT NULL,
  `Vendor` varchar(45) DEFAULT NULL,
  `Address` varchar(128) DEFAULT NULL,
  PRIMARY KEY (`VendorCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='供货商（医院）基础数据';

-- ----------------------------
-- Records of mwvendor
-- ----------------------------
INSERT INTO `mwvendor` VALUES ('1', '1', '1');
INSERT INTO `mwvendor` VALUES ('YY001', '东南医院1', '东南地址1');
INSERT INTO `mwvendor` VALUES ('YY002', '中南医院', '中南地址');
INSERT INTO `mwvendor` VALUES ('YY003', '西南医院', '西南地址');
INSERT INTO `mwvendor` VALUES ('YY004', '北南医院', '北南地址');
INSERT INTO `mwvendor` VALUES ('YY005', '东北医院', '东北地址');
INSERT INTO `mwvendor` VALUES ('YY006', '中北医院', '中北地址');
INSERT INTO `mwvendor` VALUES ('YY007', '西北医院', '西北地址');
INSERT INTO `mwvendor` VALUES ('YY008', '武汉医院', '武汉地址');

-- ----------------------------
-- Table structure for `mwwastecategory`
-- ----------------------------
DROP TABLE IF EXISTS `mwwastecategory`;
CREATE TABLE `mwwastecategory` (
  `WasteCode` varchar(20) NOT NULL,
  `Waste` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`WasteCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='危险品种类数据';

-- ----------------------------
-- Records of mwwastecategory
-- ----------------------------
INSERT INTO `mwwastecategory` VALUES ('00', '001');
INSERT INTO `mwwastecategory` VALUES ('YF001', 'A型废料');
INSERT INTO `mwwastecategory` VALUES ('YF002', 'B型废料');
INSERT INTO `mwwastecategory` VALUES ('YF003', 'C型废料');
INSERT INTO `mwwastecategory` VALUES ('YF004', 'D型废料');
INSERT INTO `mwwastecategory` VALUES ('YF005', 'E型废料');
INSERT INTO `mwwastecategory` VALUES ('YF006', 'F型废料');
INSERT INTO `mwwastecategory` VALUES ('YF007', 'G型废料');
INSERT INTO `mwwastecategory` VALUES ('YF008', 'H型废料');

-- ----------------------------
-- Table structure for `mwworkstation`
-- ----------------------------
DROP TABLE IF EXISTS `mwworkstation`;
CREATE TABLE `mwworkstation` (
  `WSCode` varchar(20) NOT NULL COMMENT '处置工作站，出入库工作站 WS00#\n手机终端 MWS00#',
  `Desc` varchar(45) DEFAULT NULL,
  `WSType` varchar(2) DEFAULT NULL COMMENT '工作终端类型\n1.出入库 I\n2.处置 D\n3手机 M',
  `AccessKey` varchar(40) DEFAULT NULL COMMENT '终端访问KEY',
  `SecretKey` varchar(40) DEFAULT NULL COMMENT '加密key',
  PRIMARY KEY (`WSCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='工作站基础数据表\n包含 处置工作站 出入库工作站 手机终端';

-- ----------------------------
-- Records of mwworkstation
-- ----------------------------
INSERT INTO `mwworkstation` VALUES ('MWS0001', '手机终端MWS0001', 'M', 'b413d64507824242aa02e74d71083471', '4ffc1610f837417ba1306ae5284bafd7');
INSERT INTO `mwworkstation` VALUES ('MWS0002', '手机终端MWS0002', 'W', '0f3ebd827a894846862a09c45248a2f3', '3011f03ff31e4be59cfffcd842a01347');
INSERT INTO `mwworkstation` VALUES ('MWS001', '手机终端1', 'M', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation` VALUES ('MWS002', '手机终端2', 'M', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation` VALUES ('MWS003', '手机终端3', 'M', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation` VALUES ('MWS004', '手机终端4', 'M', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation` VALUES ('MWS1001', '手机终端MWS0001', 'M', '7f792618e4c943f781f2aabfbd0158a0', '74bdc9bf9b274e45b236de953b8362c5');
INSERT INTO `mwworkstation` VALUES ('MWS1002', '手机终端MWS0002', 'M', 'a96edbb9576a468490c873555fdaf040', '7e77ccef6b5a4e41b5ebf069a67fb413');
INSERT INTO `mwworkstation` VALUES ('MWS1003', '手机终端MWS0003', 'M', '7b7cc11424a2426695998331ac3a47ef', 'de1051ebb8c542e0ac614ab0aa5b5447');
INSERT INTO `mwworkstation` VALUES ('MWS1004', '手机终端MWS0004', 'M', '04dfe3a12f604356ac1b4dd04ad4f377', '4f1b623bebb34731a708ac56964f6196');
INSERT INTO `mwworkstation` VALUES ('MWS2001', '手机终端MWS0001', 'M', 'e57585944b884d1ea93d0db66dc9fd34', '971e6a442f5c4686922e157129c2c32f');
INSERT INTO `mwworkstation` VALUES ('MWS3001', '手机终端MWS0001', 'M', 'd8ea36f3cf564df7a575ec7c5145e5a5', '4d8bea3be70d4ec9b3af9e167cd24608');
INSERT INTO `mwworkstation` VALUES ('WS001', '处置工作站', 'D', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');
INSERT INTO `mwworkstation` VALUES ('WS002', '库存工作站', 'I', '9e15f4f7d6fdc178eeab8caf79d863054bdfea78', 'ae46214f1ee0269f7eb5126895ff166f02ede4f1');

-- ----------------------------
-- Table structure for `syslog`
-- ----------------------------
DROP TABLE IF EXISTS `syslog`;
CREATE TABLE `syslog` (
  `LogId` int(11) NOT NULL,
  `Desc` varchar(45) DEFAULT NULL,
  `Remark` text,
  `LogDate` datetime DEFAULT NULL,
  PRIMARY KEY (`LogId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of syslog
-- ----------------------------

-- ----------------------------
-- Table structure for `sysnextid`
-- ----------------------------
DROP TABLE IF EXISTS `sysnextid`;
CREATE TABLE `sysnextid` (
  `IdName` varchar(128) NOT NULL,
  `MinValue` int(11) DEFAULT NULL,
  `Increment` int(11) DEFAULT NULL,
  `MaxValue` int(11) DEFAULT NULL,
  `IdValue` int(11) DEFAULT NULL,
  PRIMARY KEY (`IdName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sysnextid
-- ----------------------------
INSERT INTO `sysnextid` VALUES ('CarDispatch', '1', '1', '99999999', '2');
INSERT INTO `sysnextid` VALUES ('FunctionGroup', '1', '1', '99999999', '5');
INSERT INTO `sysnextid` VALUES ('FunctionGroupDetail', '1', '1', '99999999', '16');
INSERT INTO `sysnextid` VALUES ('InvAuthorize', '1', '1', '99999999', '2');
INSERT INTO `sysnextid` VALUES ('InvAuthorizeAttach', '1', '1', '99999999', '3');
INSERT INTO `sysnextid` VALUES ('Inventory', '1', '1', '99999999', '3');
INSERT INTO `sysnextid` VALUES ('InventoryTrack', '1', '1', '99999999', '7');
INSERT INTO `sysnextid` VALUES ('TxnDestroyHeader', '1', '1', '99999999', '2');
INSERT INTO `sysnextid` VALUES ('TxnDetail', '1', '1', '99999999', '7');
INSERT INTO `sysnextid` VALUES ('TxnLog', '1', '1', '99999999', '10');
INSERT INTO `sysnextid` VALUES ('TxnNum', '1', '1', '99999999', '5');
INSERT INTO `sysnextid` VALUES ('TxnPostHeader', '1', '1', '99999999', '3');
INSERT INTO `sysnextid` VALUES ('TxnRecoverHeader', '1', '1', '99999999', '2');
INSERT INTO `sysnextid` VALUES ('WSCode', '1', '1', '99999999', '3');

-- ----------------------------
-- Table structure for `sysparameter`
-- ----------------------------
DROP TABLE IF EXISTS `sysparameter`;
CREATE TABLE `sysparameter` (
  `ParameterName` varchar(128) NOT NULL,
  `ParameterValue` varchar(128) DEFAULT NULL,
  `Remark` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`ParameterName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- ----------------------------
-- Records of sysparameter
-- ----------------------------
INSERT INTO `sysparameter` VALUES ('ADMINISTRATOR', 'administrator', '');
INSERT INTO `sysparameter` VALUES ('ADMINISTRATORPASSWORD', 'yZR^zcwkvCjkN{DfoKTVUYP`p~H]urU^Fby]jWoPRsP', '');
INSERT INTO `sysparameter` VALUES ('AllowDiffWeight', '1', null);
INSERT INTO `sysparameter` VALUES ('CRATECODEMASK', 'HX###', '');
