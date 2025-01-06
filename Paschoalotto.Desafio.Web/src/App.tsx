import { useEffect, useState } from "react";
import { User } from "./models/user";
import UserService from "./services/user-service";
import { AxiosError } from "axios";
import { ResponseModel } from "./models/response-model";

function App() {
  const [users, setUsers] = useState<User[]>([]);

  useEffect(() => {
    UserService.getAll()
      .then((res) => {
        setUsers(res.data.data || []);

        console.log(res.data);
      })
      .catch((err) => {
        if (err instanceof AxiosError)
          alert(
            "Erro ao carregar os usuários: " +
              (err.response?.data as ResponseModel<unknown>).errorMessage
          );
      });
  }, []);

  return (
    <main>
      <table>
        <thead>
          <tr>
            <th>Imagem</th>
            <th>Nome</th>
            <th>Usuário</th>
            <th>Email</th>
          </tr>
        </thead>

        <tbody>
          {users.map((user) => (
            <tr key={user.id}>
              <td>
                <img src={user.picture} width={64} height={64} />
              </td>
              <td width="100%">{user.fullName}</td>
              <td>@{user.username}</td>
              <td>{user.email}</td>
            </tr>
          ))}
        </tbody>
      </table>
    </main>
  );
}

export default App;
