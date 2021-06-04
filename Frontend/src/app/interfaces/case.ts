import {TeamMember} from './team-member';

export interface Case {
  id: string;
  teamMember: TeamMember;
  status: string;
  updatedAt: Date;
}
