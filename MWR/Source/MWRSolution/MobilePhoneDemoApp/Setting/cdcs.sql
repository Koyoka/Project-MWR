-- MySQL Script generated by MySQL Workbench
-- 06/09/15 16:36:38
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema cdcs
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema cdcs
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `cdcs` DEFAULT CHARACTER SET utf8 ;
USE `cdcs` ;
USE `cdcs` ;

-- -----------------------------------------------------
-- procedure GetData_Count_All
-- -----------------------------------------------------

DELIMITER $$
USE `cdcs`$$
CREATE DEFINER=`root`@`%` PROCEDURE `GetData_Count_All`(in startdate varchar(20),in enddate varchar(20),in city varchar(50),in curprovince int, out str varchar(5000))
begin
	declare tmp_num decimal(10,3);
	declare j int;
	declare one_arr_data VARCHAR(2000);
	declare curr_arr_data VARCHAR(2000);
	set j = 1;
	while j<=7 do
		 if city= '99' then
	   		select a.name, sum(b.num) as month_num into tmp_num from bus_city a,bus_data b  where b.opt_type=j and b.addtime between startdate and enddate   and  a.province=curprovince group by a.name;
		else
			select a.name, sum(b.num) as month_num into tmp_num from bus_city a,bus_data b  where b.opt_type=j and b.addtime between startdate and enddate   and  a.province=curprovince and a.id=city group by a.name;
		end if;
		set j = j+1;
	end while;
	select tmp_num;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetData_Line_All
-- -----------------------------------------------------

DELIMITER $$
USE `cdcs`$$
CREATE DEFINER=`root`@`%` PROCEDURE `GetData_Line_All`(in yearnum int,in startmon int,in endmon int,in curprovince int, out str varchar(5000))
begin
	declare tmp_num decimal(10,3);
	declare i int;
	declare j int;
	declare one_arr_data VARCHAR(2000);
	declare curr_arr_data VARCHAR(2000);
	set curr_arr_data = '';
	set one_arr_data = '|';
	set i=1;
	set j = startmon;
	while j<=endmon do
		while i<=7 do
			select sum(num) as month_num into tmp_num from bus_data  where opt_type=i and _month=j and _year=yearnum  and  province=curprovince;
			set i = i + 1;
			set one_arr_data = concat(one_arr_data,",",tmp_num);
		end while;
		set curr_arr_data = concat(curr_arr_data,one_arr_data);
		set j=j+1;
		set i=1;
		set one_arr_data = '|';
	end while;
	set str = curr_arr_data;
	select str;
end$$

DELIMITER ;

-- -----------------------------------------------------
-- procedure GetData_Stack_All
-- -----------------------------------------------------

DELIMITER $$
USE `cdcs`$$
CREATE DEFINER=`root`@`%` PROCEDURE `GetData_Stack_All`(in yearnum int,in curryearnum int,in monthnum int,in curprovince int,out str VARCHAR(1000))
begin
	declare tmp_num decimal(10,3);
	declare cur_num decimal(10,3);
	declare i int;
	declare curr_arr_data VARCHAR(500);
	declare last_arr_data VARCHAR(500);
	select sum(num) as month_num into tmp_num from bus_data  where opt_type=1 and _month=monthnum and _year=yearnum and  province=curprovince;
	set last_arr_data = tmp_num;
	select sum(num) as month_num into cur_num from bus_data  where opt_type=1 and _month=monthnum and _year=curryearnum and  province=curprovince;
	set curr_arr_data =cur_num;
	set i=2;
	while i<8 do
		select sum(num) as month_num into tmp_num from bus_data  where opt_type= i and _month=monthnum and _year=yearnum and  province=curprovince;
		set last_arr_data = concat(last_arr_data,",",tmp_num);
		select sum(num) as month_num into cur_num from bus_data  where opt_type= i and _month=monthnum and _year=curryearnum and  province=curprovince;
		set curr_arr_data = concat(curr_arr_data,",",cur_num);
		set i= i+1;
	end while;

	set str =  concat(curr_arr_data,"*",last_arr_data);
end$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
