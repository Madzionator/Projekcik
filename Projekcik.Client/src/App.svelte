<script>
  import RegisterPage from "./Pages/Auth/RegisterPage.svelte";
  import { Router, Link, Route } from "svelte-navigator";
  import Header from "./Components/Header.svelte";
  import ErrorPage from "./Pages/ErrorPage.svelte";
  import HomePage from "./Pages/HomePage.svelte";
  import HelloWorld from "./Components/HelloWorld.svelte";
  import AddTodoPage from "./Pages/Todo/AddTodoPage.svelte";
  import ListTodoPage from "./Pages/Todo/ListTodoPage.svelte";
  import LoginPage from "./Pages/Auth/LoginPage.svelte";
  import { SvelteToast } from "@zerodevx/svelte-toast";
  import EditTodoPage from "./Pages/Todo/EditTodoPage.svelte";

  const routes = [
    { path: "/", component: HomePage },
    { path: "helloworld", component: HelloWorld },
    { path: "register", component: RegisterPage },
    { path: "login", component: LoginPage },
    { path: "todo", component: ListTodoPage },
    { path: "todo/add", component: AddTodoPage },
    { path: "todo/edit/:id", component: EditTodoPage },
  ];
</script>

<Router>
  <Header />
  <div>
    {#each routes as route}
      <Route {...route} />
    {/each}
    <Route component={ErrorPage} />
  </div>
</Router>
<SvelteToast />
