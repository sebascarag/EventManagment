import { EType } from "src/app/shared/enums/etype.enum";

export interface EventLogDto{
  id:           number;
  date:         Date;
  description:  string;
  eType:        EType;
  eTypeText:    string;
}
