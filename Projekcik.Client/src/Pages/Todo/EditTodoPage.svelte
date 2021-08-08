<script>
  import { toast } from "@zerodevx/svelte-toast";

  import { onMount } from "svelte";
  import { navigate } from "svelte-navigator";
  import EditTodoItem from "../../Components/EditTodoItem.svelte";
  import TodoService from "../../Services/TodoService";

  export let id;
  let todo;

  onMount(async () => {
    TodoService.getTodo(id)
      .then((response) => {
        todo = {
          ...response,
          termin: new Date(response.termin),
        };
      })
      .catch((xd) => {
        toast.push("błąd");
        navigate("/todo", { replace: true });
      });
  });
</script>

{#if todo}
  <EditTodoItem
    {...todo}
    onSave={(td) => {
      TodoService.editTodo(td, todo.id)
        .then((response) => {
          toast.push("Udało się edytować zadanie 😻");
          navigate("/todo", { replace: true });
        })
        .catch((response) => toast.push("Nie udało się edytować zadania 😿"));
    }}
  />
{/if}

<!-- 
    //on mount: pobieramy obiekt 
    //przekazujemy go do EditTodoItem 
-->
