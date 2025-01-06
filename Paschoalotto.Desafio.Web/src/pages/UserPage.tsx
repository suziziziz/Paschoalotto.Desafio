import { useEffect, useState } from "react";
import { useParams } from "react-router";
import UserService from "../services/user-service";
import { User } from "../models/user";
import { AxiosError } from "axios";
import { ResponseModel } from "../models/response-model";

export default function UserPage() {
  const { slug } = useParams();

  const [user, setUser] = useState<User>();

  useEffect(() => {
    if (!slug) return;

    UserService.getById(slug)
      .then((res) => setUser(res.data.data))
      .catch((err) => {
        if (err instanceof AxiosError)
          alert(
            "Erro ao carregar o usuário: " +
              (err.response?.data as ResponseModel<unknown>).errorMessage
          );
      });
  }, [slug]);

  function handleSubmit(ev: React.FormEvent) {
    ev.preventDefault();

    if (!user || !slug) return;

    UserService.update(slug, user)
      .then(() => {
        alert("Usuário atualizado!");
        location.reload();
      })
      .catch((err) => {
        if (err instanceof AxiosError)
          alert(
            "Erro ao carregar o usuário: " +
              (err.response?.data as ResponseModel<unknown>).errorMessage
          );
      });
  }

  if (!user) return <center>Carregando...</center>;

  return (
    <main>
      <a href="..">Voltar</a>
      <form
        style={{ display: "flex", gap: "1rem", maxWidth: "none" }}
        onSubmit={handleSubmit}
      >
        <div>
          <img src={user?.picture} width={196} height={196} />
        </div>
        <div style={{ flex: 1 }}>
          <label>
            Url da imagem
            <input
              type="url"
              defaultValue={user?.picture}
              onChange={(e) => setUser({ ...user, picture: e.target.value })}
              style={{ width: "100%" }}
            />
          </label>

          <label>
            Nome Completo *
            <input
              required
              type="text"
              defaultValue={user?.fullName}
              onChange={(e) => setUser({ ...user, fullName: e.target.value })}
              style={{ width: "100%" }}
            />
          </label>

          <label>
            Nome de usuário *
            <input
              required
              type="text"
              defaultValue={user?.username}
              onChange={(e) => setUser({ ...user, username: e.target.value })}
              style={{ width: "100%" }}
            />
          </label>

          <label>
            Email *
            <input
              required
              type="email"
              defaultValue={user?.email}
              onChange={(e) => setUser({ ...user, email: e.target.value })}
              style={{ width: "100%" }}
            />
          </label>

          <label>
            Senha *
            <input
              required
              type="password"
              defaultValue={user?.password}
              onChange={(e) => setUser({ ...user, password: e.target.value })}
              style={{ width: "100%" }}
            />
          </label>

          <div>
            <button style={{ padding: ".25rem 1rem" }} type="submit">
              Salvar
            </button>
          </div>
        </div>
      </form>
    </main>
  );
}
