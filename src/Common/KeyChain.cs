using OneOf;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace AvalancheDotNet.Common
{

    ///**
    // * Class for representing a private and public keypair in Avalanche. 
    // * All APIs that need key pairs should extend on this class.
    // */
    abstract class StandardKeyPair
    {
        protected Buffer pubk;
        protected Buffer privk;

        /**
           * Generates a new keypair.
           *
           * @param entropy Optional parameter that may be necessary to produce secure keys
           */
        public abstract void GenerateKey(Buffer entropy);

        //    /**
        //       * Imports a private key and generates the appropriate public key.
        //       *
        //       * @param privk A {@link https://github.com/feross/buffer|Buffer} representing the private key
        //       *
        //       * @returns true on success, false on failure
        //       */
        public abstract bool ImportKey(Buffer privateKey);

        //    /**
        //       * Takes a message, signs it, and returns the signature.
        //       *
        //       * @param msg The message to sign
        //       *
        //       * @returns A {@link https://github.com/feross/buffer|Buffer} containing the signature
        //       */
        public abstract Buffer Sign(Buffer msg);

        //    /**
        //       * Recovers the public key of a message signer from a message and its associated signature.
        //       *
        //       * @param msg The message that's signed
        //       * @param sig The signature that's signed on the message
        //       *
        //       * @returns A {@link https://github.com/feross/buffer|Buffer} containing the public
        //       * key of the signer
        //       */
        public abstract Buffer Recover(Buffer msg, Buffer sig);

        //    /**
        //       * Verifies that the private key associated with the provided public key produces the
        //       * signature associated with the given message.
        //       *
        //       * @param msg The message associated with the signature
        //       * @param sig The signature of the signed message
        //       * @param pubk The public key associated with the message signature
        //       *
        //       * @returns True on success, false on failure
        //       */
        public abstract bool Verify(Buffer msg, Buffer sig, Buffer pubk);

        //    /**
        //       * Returns a reference to the private key.
        //       *
        //       * @returns A {@link https://github.com/feross/buffer|Buffer} containing the private key
        //       */
        public Buffer PrivateKey => this.privk;

        //    /**
        //       * Returns a reference to the public key.
        //       *
        //       * @returns A {@link https://github.com/feross/buffer|Buffer} containing the public key
        //       */
        public Buffer PublicKey => this.pubk;

        //    /**
        //       * Returns a string representation of the private key.
        //       *
        //       * @returns A string representation of the public key
        //       */
        public abstract string PrivateKeyString { get; }

        //    /**
        //       * Returns the public key.
        //       *
        //       * @returns A string representation of the public key
        //       */
        public abstract string PublicKeyString { get; }
        //    /**
        //       * Returns the address.
        //       *
        //       * @returns A {@link https://github.com/feross/buffer|Buffer}  representation of the address
        //       */
        public abstract Buffer GetAddress();

        //    /**
        //     * Returns the address's string representation.
        //     * 
        //     * @returns A string representation of the address
        //     */
        public abstract string GetAddressString();

        //    abstract create(...args:any[]):this;

        //    abstract clone():this;

    }

    //  /**
    //   * Class for representing a key chain in Avalanche.
    //   * All endpoints that need key chains should extend on this class.
    //   *
    //   * @typeparam KPClass extending [[StandardKeyPair]] which is used as the key in [[StandardKeyChain]]
    //   */
    abstract class StandardKeyChain<KPClass> where KPClass : StandardKeyPair
    {
        //  export abstract class StandardKeyChain<KPClass extends StandardKeyPair> {
        //  export abstract class StandardKeyChain<KPClass extends StandardKeyPair> {
        protected Dictionary<string, KPClass> keys = new();

        //    /**
        //       * Makes a new [[StandardKeyPair]], returns the address.
        //       *
        //       * @returns Address of the new [[StandardKeyPair]]
        //       */
        public abstract KPClass MakeKey();

        //    /**
        //       * Given a private key, makes a new [[StandardKeyPair]], returns the address.
        //       *
        //       * @param privk A {@link https://github.com/feross/buffer|Buffer} representing the private key
        //       *
        //       * @returns A new [[StandardKeyPair]]
        //       */
        public abstract KPClass ImportKey(Buffer privk);

        //    /**
        //       * Gets an array of addresses stored in the [[StandardKeyChain]].
        //       *
        //       * @returns An array of {@link https://github.com/feross/buffer|Buffer}  representations
        //       * of the addresses
        //       */
        public IEnumerable<Buffer> GetAddresses()
        {
            return keys.Select(x => x.Value.GetAddress());
        }
        //    /**
        //       * Gets an array of addresses stored in the [[StandardKeyChain]].
        //       *
        //       * @returns An array of string representations of the addresses
        //       */
        public IEnumerable<string> GetAddressStrings()
        {
            return keys.Select(x => x.Value.GetAddressString());
        }
        //    /**
        //       * Adds the key pair to the list of the keys managed in the [[StandardKeyChain]].
        //       *
        //       * @param newKey A key pair of the appropriate class to be added to the [[StandardKeyChain]]
        //       */
        public void addKey(KPClass newKey)
        {
            this.keys[newKey.GetAddress().ToHexString()] = newKey;
        }

        //    /**
        //       * Removes the key pair from the list of they keys managed in the [[StandardKeyChain]].
        //       *
        //       * @param key A {@link https://github.com/feross/buffer|Buffer} for the address or
        //       * KPClass to remove
        //       *
        //       * @returns The boolean true if a key was removed.
        //       */
        public bool RemoveKey(OneOf<KPClass, Buffer> key)
        {
            string kaddr;
            if (key.IsT0)
            {
                kaddr = key.AsT0.GetAddress().ToHexString();
            }
            else
            {
                kaddr = key.AsT1.ToHexString();
            }
            if (this.keys.ContainsKey(kaddr))
            {
                this.keys.Remove(kaddr);
                return true;
            }
            return false;   
        }
        //    /**
        //       * Checks if there is a key associated with the provided address.
        //       *
        //       * @param address The address to check for existence in the keys database
        //       *
        //       * @returns True on success, false if not found
        //       */
        public bool HasKey(Buffer address)
        {
            return this.keys.ContainsKey(address.ToHexString());
        }
        //    /**
        //       * Returns the [[StandardKeyPair]] listed under the provided address
        //       *
        //       * @param address The {@link https://github.com/feross/buffer|Buffer} of the address to
        //       * retrieve from the keys database
        //       *
        //       * @returns A reference to the [[StandardKeyPair]] in the keys database
        //       */
        public KPClass GetKey(Buffer address)
        {
            return this.keys[address.ToHexString()];
        }

        //    abstract create(...args:any[]):this;

        //    abstract clone():this;

        //    abstract union(kc:this):this;

        //  }
    }
}
