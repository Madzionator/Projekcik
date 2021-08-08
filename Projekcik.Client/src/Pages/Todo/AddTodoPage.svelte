<script>
  import { navigate } from "svelte-navigator";

  import EditTodoItem from "../../Components/EditTodoItem.svelte";
  import TodoService from "../../Services/TodoService";
  import { toast } from "@zerodevx/svelte-toast";
</script>

<EditTodoItem
  onSave={(todo) => {
    TodoService.createTodo(todo)
      .then((response) => {
        toast.push("Udało się dodać zadanie 😻");
        navigate("/todo", { replace: true });
      })
      .catch((response) => toast.push("Nie udało się dodać zadania 😿"));
  }}
/>
