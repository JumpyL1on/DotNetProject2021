import {TeamMember} from './team-member';
import {LastMessage} from './last-message';
import {Client} from './client';

export interface Case {
  id: string;
  teamMember: TeamMember;
  client: Client;
  status: string;
  //lastMessage: LastMessage;
  updatedAt: Date;
}
