export interface Message {
  type: string;
  text: string;
  reply: boolean;
  sender: string;
  createdAt: Date;
}
