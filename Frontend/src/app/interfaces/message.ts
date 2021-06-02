export interface Message {
  type: string;
  text: string;
  reply: boolean;
  createdAt: Date;
}
