import Api from "./Api";

export const getHelloWorldList = async () => {
    try {
      const response = await Api.get("/HelloWorld");
      return response;
    } catch (error) {
      console.error(error);
    }
};

export const postHelloWorld = async (name) => {
    try {
      const response = await Api.post("/HelloWorld", name );
      return response;
    } catch (error) {
      console.error(error);
    }
};

export const removeHelloWorld = async (id) => {
    try {
      const response = await Api.delete(`/HelloWorld/${id}` );
      return response;
    } catch (error) {
      console.error(error);
    }
};