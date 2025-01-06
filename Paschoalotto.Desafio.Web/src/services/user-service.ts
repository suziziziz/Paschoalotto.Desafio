import axios from "axios";
import { User } from "../models/user";
import { ResponseModel } from "../models/response-model";

export default class UserService {
  static api = axios.create({ baseURL: import.meta.env.VITE_API_URL });

  private constructor() {}

  static getAll() {
    return this.api.get<ResponseModel<User[]>>("/User");
  }

  static getById(id: string) {
    return this.api.get<ResponseModel<User>>(`/User/${id}`);
  }

  static update(id: string, user: User) {
    return this.api.put(`/User/${id}`, user);
  }
}
