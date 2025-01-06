import { Entity } from "./entity";

export class User extends Entity {
  fullName!: string;
  username!: string;
  email!: string;
  password!: string;
  picture?: string;
}
