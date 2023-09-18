import { EType } from "src/app/shared/enums/etype.enum";

export interface AddEventLogs{
  date?:         Date;
  description:  string;
  eType:        EType;
}
