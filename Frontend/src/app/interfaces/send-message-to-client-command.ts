export interface SendMessageToClientCommand {
  caseId: string;
  clientId: number;
  text: string;
  sender: string;
  createdAt: Date;
}
