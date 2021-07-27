<script>
  import TodoService from "../Services/TodoService";
  import TodoElement from "../Components/TodoElement.svelte";
  import { navigate } from "svelte-navigator";
  import { onMount } from "svelte";
  let todos = [];

  onMount(async () => {
    console.log("mounted!");
    Refresh();
  });

  function Refresh() {
    TodoService.getTodoList().then((response) => {
      todos = response;
    });
  }
  function TodoAdd() {
    navigate("/todo/add", { replace: true });
  }

  function onDeleteTodoXD(todoId) {
    TodoService.deleteTodo(todoId)
      .then((data) => {
        Refresh();
      })
      .catch((response) => {
        console.log(response);
      });
  }
</script>

<div class="container">
  <button class="dodaj" on:click={TodoAdd}> + dodaj zadanie </button>
  <div class="row">
    {#each todos as todo}
      <TodoElement {todo} onDeleteTodo={() => onDeleteTodoXD(todo.id)} />
    {/each}
  </div>
</div>

<style>
  .dodaj {
    border: 2px solid black;
    height: 50px;
    width: 150px;
    border-radius: 20px;
    margin: 8px;
    font-weight: bold;
  }
</style>
