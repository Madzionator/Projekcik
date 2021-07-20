<script>
  import TodoService from "../Services/TodoService";
  import TodoElement from "../Components/TodoElement.svelte";
  import { navigate } from "svelte-navigator";
  import { onMount } from "svelte";
  let todos = [];

  onMount(async () => {
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
</script>

<div class="container">
  <button class="dodaj" on:click={TodoAdd}> + dodaj zadanie </button>
  <div class="row">
    {#each todos as todo}
      <TodoElement {todo} />
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
