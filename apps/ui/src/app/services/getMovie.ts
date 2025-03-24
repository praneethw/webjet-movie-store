import { Movie } from './getMovies'

export const getMovie = async (id: string): Promise<Movie> => { 
    const response = await fetch(`http://localhost:4200/api/movies/${id}`);
    if(response.ok) {
        return response.json();
    }

    return Promise.reject('Error retrieving movies');
 } 