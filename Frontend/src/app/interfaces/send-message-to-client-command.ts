export interface SendMessageToClientCommand {
  caseId: string;
  clientId: number;
  text: string;
  createdAt: Date;
}
