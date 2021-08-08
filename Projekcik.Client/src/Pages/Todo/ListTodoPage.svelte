<script>
  import TodoItem from "../../Components/TodoItem.svelte";
  import TodoService from "../../Services/TodoService";
  import { navigate } from "svelte-navigator";
  import { onMount } from "svelte";

  let todos = [];
  let loading = true;

  onMount(async () => {
    Refresh();
  });

  function Refresh() {
    loading = true;
    TodoService.getTodoList().then((response) => {
      todos = response.map((x) => ({
        ...x,
        termin: new Date(x.termin),
      }));
      loading = false;
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
      .catch((response) => {});
  }

  function onEditTodo(todoId) {
    navigate(`/todo/edit/${todoId}`, { replace: true });
  }
</script>

<div class="container">
  <div class="py-3">
    <button class="btn btn-outline-primary dodaj" on:click={TodoAdd}>
      <span class="fa fa-plus" aria-hidden="true" /> Dodaj zadanie
    </button>
  </div>
  <div class="row">
    {#each todos as todo}
      <TodoItem
        {...todo}
        onDeleteTodo={() => onDeleteTodoXD(todo.id)}
        onEditTodo={() => onEditTodo(todo.id)}
      />
    {/each}

    {#if loading}
      <div class="spinner-border" role="status">
        <span class="visually-hidden">Loading...</span>
      </div>
    {/if}
  </div>
</div>

<style>
  .dodaj {
  }
</style>
