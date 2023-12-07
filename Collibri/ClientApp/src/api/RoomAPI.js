export const deleteRoom = (roomId, setRooms) => {
    fetch(`/v1/rooms/${roomId}`, { method: "DELETE" })
        .then((response) => response.text())
        .then((data) => {
            console.log(data);
            setRooms((prevRooms) => prevRooms.filter(room => room.id !== roomId));
        })
        .catch(error => console.error('Error deleting room:', error));
};

export const createRoom = (roomName, setRooms) => {
    fetch('/v1/rooms', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            Name: roomName,
        }),
    })
        .then(response => {
            if (!response.ok) {
                throw new Error('Failed to create room');
            }
            return response.json();
        })
        .then(data => {
            console.log('Room created successfully:', data);
            setRooms((prevRooms) => [...prevRooms, data]);
        })
        .catch(error => {
            console.error('Error creating room:', error.message);
        });
}

export const updateRoom = (roomId, updatedRoom, rooms, setRooms) => {
    
    fetch(`/v1/rooms/${roomId}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(updatedRoom)
    })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            const updatedRooms = [...rooms];
            const roomIndex = updatedRooms.findIndex(room => room.id === roomId);
            updatedRooms[roomIndex] = data;
            setRooms(updatedRooms);
        })
        .catch(error => console.error('Error updating section:', error));
};

export const getRooms = (setRooms,setSkeleton) => {
    fetch('/v1/rooms', { method: "GET" })
        .then((response) => response.json())
        .then((data) => {
            console.log(data);
            // setSkeleton(false);
            setRooms(data);
        })
        .catch(error => console.error('Error fetching data', error));
}