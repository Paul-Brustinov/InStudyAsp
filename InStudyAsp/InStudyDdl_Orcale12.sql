--------------------------------------------------------
--  File created - �����������-��������-04-2017   
--------------------------------------------------------
--------------------------------------------------------
--  DDL for Table DISCIPLINE
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."DISCIPLINE" 
   (	"DISCIPLINE_CODE" NUMBER(*,0), 
	"DISCIPLINE_NAME" VARCHAR2(50 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table FAQS
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."FAQS" 
   (	"STUDENT_ID" NUMBER, 
	"TASK_ID" NUMBER, 
	"FAQS_QUESTION_TIME" DATE, 
	"FAQS_QUESTION" VARCHAR2(500 BYTE), 
	"TEACHER_ID" NUMBER, 
	"FAQS_ANSWER_TIME" DATE, 
	"FAQS_ANSWER" VARCHAR2(500 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table GROUP
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."GROUP" 
   (	"GROUP_CODE" VARCHAR2(10 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table STUDENT
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."STUDENT" 
   (	"STUDENT_ID" NUMBER, 
	"GROUP_CODE" VARCHAR2(10 BYTE), 
	"STUDENT_START" DATE, 
	"USER_PHONE" VARCHAR2(20 BYTE), 
	"STUDENT_END" DATE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table SCHEDULE
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."SCHEDULE" 
   (	"TEACHER_ID" NUMBER, 
	"GROUP_CODE" VARCHAR2(10 BYTE), 
	"DISCIPLINE_CODE" NUMBER(*,0), 
	"SCHEDULE_DATE" DATE, 
	"SCHEDULE_ROOM" NUMBER
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table STUDENTWORK
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."STUDENTWORK" 
   (	"STUDENT_ID" NUMBER, 
	"TASK_ID" NUMBER, 
	"STUDENT_WORK_FILE" BLOB, 
	"STUDENT_WORK_TEXT" VARCHAR2(500 BYTE), 
	"STUDENT_WORK_MARK" NUMBER(*,0), 
	"STUDENT_WORK_DATE" DATE
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" 
 LOB ("STUDENT_WORK_FILE") STORE AS SECUREFILE (
  TABLESPACE "USERS" ENABLE STORAGE IN ROW CHUNK 8192
  NOCACHE LOGGING  NOCOMPRESS  KEEP_DUPLICATES ) ;
--------------------------------------------------------
--  DDL for Table TASK
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."TASK" 
   (	"TASK_ID" NUMBER, 
	"PARENT_TASK_ID" NUMBER, 
	"DISCIPLINE_CODE" NUMBER(*,0), 
	"TASK_DATE" DATE, 
	"TASK_TYPE_CODE" NUMBER(*,0), 
	"TASK_DESCRIPTION" VARCHAR2(500 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table TASKTYPES
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."TASKTYPES" 
   (	"TASK_TYPE_CODE" NUMBER(*,0), 
	"TASK_TYPE_NAME" VARCHAR2(200 BYTE)
   ) SEGMENT CREATION DEFERRED 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table TEACHER
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."TEACHER" 
   (	"TEACHER_ID" NUMBER, 
	"USER_PHONE" VARCHAR2(20 BYTE), 
	"TEACHER_START" DATE, 
	"TEACHER_END" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Table USER
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."USER" 
   (	"USER_PHONE" VARCHAR2(20 BYTE), 
	"USER_PASSWORD" VARCHAR2(255 BYTE), 
	"USER_EMAIL" VARCHAR2(50 BYTE), 
	"USER_FIRSTNAME" VARCHAR2(20 BYTE), 
	"USER_LASTNAME" VARCHAR2(20 BYTE), 
	"USER_BIRTHDAY" DATE, 
	"USER_AVATAR" BLOB, 
	"USER_IS_ACTIVATED" NUMBER(*,0)
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" 
 LOB ("USER_AVATAR") STORE AS SECUREFILE (
  TABLESPACE "USERS" ENABLE STORAGE IN ROW CHUNK 8192
  NOCACHE LOGGING  NOCOMPRESS  KEEP_DUPLICATES 
  STORAGE(INITIAL 106496 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)) ;
--------------------------------------------------------
--  DDL for Table USER_SESSION
--------------------------------------------------------

  CREATE TABLE "C##INSTUDY"."USER_SESSION" 
   (	"USER_PHONE_FK" VARCHAR2(20 BYTE), 
	"SESSION_DATETIME" DATE, 
	"SESSION_HASH" VARCHAR2(512 BYTE), 
	"SESSION_EXPIRE" DATE
   ) SEGMENT CREATION IMMEDIATE 
  PCTFREE 10 PCTUSED 40 INITRANS 1 MAXTRANS 255 
 NOCOMPRESS LOGGING
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_DISCIPLINE
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_DISCIPLINE" ON "C##INSTUDY"."DISCIPLINE" ("DISCIPLINE_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_FAQS
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_FAQS" ON "C##INSTUDY"."FAQS" ("STUDENT_ID", "TASK_ID", "FAQS_QUESTION_TIME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TASK_FAQS_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."TASK_FAQS_FK" ON "C##INSTUDY"."FAQS" ("TASK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index STUDENT_QUESTION_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."STUDENT_QUESTION_FK" ON "C##INSTUDY"."FAQS" ("STUDENT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TEACHER_ANSWER_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."TEACHER_ANSWER_FK" ON "C##INSTUDY"."FAQS" ("TEACHER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_GROUP
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_GROUP" ON "C##INSTUDY"."GROUP" ("GROUP_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_STUDENT
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_STUDENT" ON "C##INSTUDY"."STUDENT" ("STUDENT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USER_STUDENT_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."USER_STUDENT_FK" ON "C##INSTUDY"."STUDENT" ("USER_PHONE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index STUDENT_IN_GROUP_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."STUDENT_IN_GROUP_FK" ON "C##INSTUDY"."STUDENT" ("GROUP_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_SCHEDULE
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_SCHEDULE" ON "C##INSTUDY"."SCHEDULE" ("TEACHER_ID", "GROUP_CODE", "DISCIPLINE_CODE", "SCHEDULE_DATE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SCHEDULE_DISCIPLINE_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."SCHEDULE_DISCIPLINE_FK" ON "C##INSTUDY"."SCHEDULE" ("DISCIPLINE_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SCHEDULE_TEACHER_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."SCHEDULE_TEACHER_FK" ON "C##INSTUDY"."SCHEDULE" ("TEACHER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SCHEDULE_GROUP_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."SCHEDULE_GROUP_FK" ON "C##INSTUDY"."SCHEDULE" ("GROUP_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_STUDENTWORK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_STUDENTWORK" ON "C##INSTUDY"."STUDENTWORK" ("STUDENT_ID", "TASK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TASK_WORK_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."TASK_WORK_FK" ON "C##INSTUDY"."STUDENTWORK" ("TASK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index STUDENT_WORK_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."STUDENT_WORK_FK" ON "C##INSTUDY"."STUDENTWORK" ("STUDENT_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index DISCIPLINE_TASK_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."DISCIPLINE_TASK_FK" ON "C##INSTUDY"."TASK" ("DISCIPLINE_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index SUB_TASK_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."SUB_TASK_FK" ON "C##INSTUDY"."TASK" ("PARENT_TASK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index TASK_TYPE_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."TASK_TYPE_FK" ON "C##INSTUDY"."TASK" ("TASK_TYPE_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_TASK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_TASK" ON "C##INSTUDY"."TASK" ("TASK_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_TASKTYPES
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_TASKTYPES" ON "C##INSTUDY"."TASKTYPES" ("TASK_TYPE_CODE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_TEACHER
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_TEACHER" ON "C##INSTUDY"."TEACHER" ("TEACHER_ID") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USER_TEACHER_FK
--------------------------------------------------------

  CREATE INDEX "C##INSTUDY"."USER_TEACHER_FK" ON "C##INSTUDY"."TEACHER" ("USER_PHONE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 COMPUTE STATISTICS 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index PK_USER
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."PK_USER" ON "C##INSTUDY"."USER" ("USER_PHONE") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  DDL for Index USER_SESSION_PK
--------------------------------------------------------

  CREATE UNIQUE INDEX "C##INSTUDY"."USER_SESSION_PK" ON "C##INSTUDY"."USER_SESSION" ("USER_PHONE_FK", "SESSION_DATETIME") 
  PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS" ;
--------------------------------------------------------
--  Constraints for Table DISCIPLINE
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."DISCIPLINE" MODIFY ("DISCIPLINE_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."DISCIPLINE" MODIFY ("DISCIPLINE_NAME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."DISCIPLINE" ADD CONSTRAINT "PK_DISCIPLINE" PRIMARY KEY ("DISCIPLINE_CODE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table FAQS
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."FAQS" MODIFY ("STUDENT_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."FAQS" MODIFY ("TASK_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."FAQS" MODIFY ("FAQS_QUESTION_TIME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."FAQS" MODIFY ("FAQS_QUESTION" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."FAQS" ADD CONSTRAINT "PK_FAQS" PRIMARY KEY ("STUDENT_ID", "TASK_ID", "FAQS_QUESTION_TIME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table GROUP
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."GROUP" MODIFY ("GROUP_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."GROUP" ADD CONSTRAINT "PK_GROUP" PRIMARY KEY ("GROUP_CODE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table STUDENT
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."STUDENT" MODIFY ("STUDENT_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENT" MODIFY ("GROUP_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENT" MODIFY ("STUDENT_START" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENT" ADD CONSTRAINT "PK_STUDENT" PRIMARY KEY ("STUDENT_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table SCHEDULE
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."SCHEDULE" MODIFY ("TEACHER_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."SCHEDULE" MODIFY ("GROUP_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."SCHEDULE" MODIFY ("DISCIPLINE_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."SCHEDULE" MODIFY ("SCHEDULE_DATE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."SCHEDULE" MODIFY ("SCHEDULE_ROOM" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."SCHEDULE" ADD CONSTRAINT "PK_SCHEDULE" PRIMARY KEY ("TEACHER_ID", "GROUP_CODE", "DISCIPLINE_CODE", "SCHEDULE_DATE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table STUDENTWORK
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."STUDENTWORK" MODIFY ("STUDENT_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENTWORK" MODIFY ("TASK_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENTWORK" MODIFY ("STUDENT_WORK_TEXT" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENTWORK" MODIFY ("STUDENT_WORK_DATE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."STUDENTWORK" ADD CONSTRAINT "PK_STUDENTWORK" PRIMARY KEY ("STUDENT_ID", "TASK_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TASK
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."TASK" MODIFY ("TASK_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASK" MODIFY ("DISCIPLINE_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASK" MODIFY ("TASK_DATE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASK" MODIFY ("TASK_TYPE_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASK" ADD CONSTRAINT "PK_TASK" PRIMARY KEY ("TASK_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TASKTYPES
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."TASKTYPES" MODIFY ("TASK_TYPE_CODE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASKTYPES" MODIFY ("TASK_TYPE_NAME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TASKTYPES" ADD CONSTRAINT "PK_TASKTYPES" PRIMARY KEY ("TASK_TYPE_CODE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table TEACHER
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."TEACHER" MODIFY ("TEACHER_ID" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TEACHER" MODIFY ("USER_PHONE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TEACHER" MODIFY ("TEACHER_START" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."TEACHER" ADD CONSTRAINT "PK_TEACHER" PRIMARY KEY ("TEACHER_ID")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table USER
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_PHONE" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_PASSWORD" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_EMAIL" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_FIRSTNAME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_LASTNAME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" MODIFY ("USER_BIRTHDAY" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER" ADD CONSTRAINT "PK_USER" PRIMARY KEY ("USER_PHONE")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
--------------------------------------------------------
--  Constraints for Table USER_SESSION
--------------------------------------------------------

  ALTER TABLE "C##INSTUDY"."USER_SESSION" MODIFY ("USER_PHONE_FK" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER_SESSION" MODIFY ("SESSION_DATETIME" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER_SESSION" MODIFY ("SESSION_HASH" NOT NULL ENABLE);
  ALTER TABLE "C##INSTUDY"."USER_SESSION" ADD CONSTRAINT "USER_SESSION_PK" PRIMARY KEY ("USER_PHONE_FK", "SESSION_DATETIME")
  USING INDEX PCTFREE 10 INITRANS 2 MAXTRANS 255 
  STORAGE(INITIAL 65536 NEXT 1048576 MINEXTENTS 1 MAXEXTENTS 2147483645
  PCTINCREASE 0 FREELISTS 1 FREELIST GROUPS 1
  BUFFER_POOL DEFAULT FLASH_CACHE DEFAULT CELL_FLASH_CACHE DEFAULT)
  TABLESPACE "USERS"  ENABLE;
