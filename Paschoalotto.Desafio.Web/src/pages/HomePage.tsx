import { AxiosError } from "axios";
import { useEffect, useState } from "react";
import { ResponseModel } from "../models/response-model";
import { User } from "../models/user";
import UserService from "../services/user-service";

export default function HomePage() {
  const [page, setPage] = useState(1);
  const [pageCount, setPageCount] = useState(1);
  const [users, setUsers] = useState<User[]>([]);

  function fetchUsers(currentPage = 1) {
    UserService.getAll({ params: { page: currentPage } })
      .then((res) => {
        setUsers(res.data.data || []);
        setPage(res.data.page || 1);
        setPageCount(res.data.pageCount || 1);
      })
      .catch((err) => {
        if (err instanceof AxiosError)
          alert(
            "Erro ao carregar os usuários: " +
              (err.response?.data as ResponseModel<unknown>).errorMessage
          );
      });
  }

  useEffect(fetchUsers, []);

  function handleChangePage(page: number) {
    setPage(page);
    fetchUsers(page);
  }

  return (
    <main>
      <table>
        <thead>
          <tr>
            <th>Imagem</th>
            <th>Nome</th>
            <th>Usuário</th>
            <th>Email</th>
            <th>Ações</th>
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
              <td>
                <a href={`/user/${user.id}`}>Acessar</a>
              </td>
            </tr>
          ))}
          &nbsp;
          <div>
            Página{" "}
            <input
              type="number"
              step={1}
              min={1}
              max={pageCount}
              value={page}
              onChange={(e) => handleChangePage(+e.target.value)}
              style={{ display: "inline", width: "2rem" }}
            />{" "}
            de {pageCount}
          </div>
        </tbody>
      </table>
    </main>
  );
}
